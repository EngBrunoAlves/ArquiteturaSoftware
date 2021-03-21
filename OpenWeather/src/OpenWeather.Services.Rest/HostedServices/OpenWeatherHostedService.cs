namespace OpenWeather.Services.Rest.HostedServices
{
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using OpenWeather.Application.Interfaces;
    using OpenWeather.Domain.Models;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using OpenWeather.Domain.Locator;

    internal class OpenWeatherHostedService : BackgroundHostedService
    {
        private const int MaxConsecutiveErrors = 10;
        private readonly IHostApplicationLifetime applicationLifetime;
        private readonly ILogger<OpenWeatherHostedService> logger;
        private readonly OpenWeatherOptions options;


        public OpenWeatherHostedService(IHostApplicationLifetime applicationLifetime, ILoggerFactory loggerFactory, IOptions<OpenWeatherOptions> options, IOpenWeatherAppService appService)
        {
            this.applicationLifetime = applicationLifetime;
            this.logger = loggerFactory.CreateLogger<OpenWeatherHostedService>();
            this.options = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var source = new CancellationTokenSource();
            cancellationToken = source.Token;

            logger.LogInformation("OpenWeatherHostedService background task is starting.");

            cancellationToken.Register(() => logger.LogWarning("OpenWeatherHostedService background task was cancelled."));

            try
            {
                var delayTime = options.CheckUpdateTimeSeconds * 1000;
                logger.LogInformation($"Get temperatures every {options.CheckUpdateTimeSeconds} seconds");

                var consecutiveErrors = 0;
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        using var appService = ServiceLocator.Resolve<IOpenWeatherAppService>();
                        foreach (var city in options.CitiesToGetTemperature)
                            await appService.PopulateCitTemperature(city);
                    }
                    catch (Exception exception)
                    {
                        consecutiveErrors++;
                        logger.LogError($"There was errors while running the hosted service. Exception: {exception.Message}");
                        if (consecutiveErrors > MaxConsecutiveErrors) throw;
                    }
                    finally
                    {
                        await Task.Delay(delayTime, cancellationToken);
                    }
                }
            }
            catch (Exception exception)
            {
                logger.LogError($"There was a critical error while executing the hosted service on ExecuteAsync method. Message: {exception.Message}\r\n StackTrace: {exception.StackTrace}");
            }
            finally
            {
                logger.LogWarning("OpenWeatherHostedService background task is stopping. Shutting down application...");
                applicationLifetime.StopApplication();
            }
        }
    }
}
