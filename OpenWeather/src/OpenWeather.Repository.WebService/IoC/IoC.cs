namespace OpenWeather.Repository.WebService.IoC
{
    using Microsoft.Extensions.DependencyInjection;
    using OpenWeather.Common.HttpCommunication.IoC;
    using OpenWeather.Domain.Interfaces.Repositories;
    using OpenWeather.Repository.WebService.Repositories;

    public static class IoC
    {
        public static void WebServiceRepositoryIoC(this IServiceCollection services)
        {
            services.AddScoped<IOpenWeatherRepository, OpenWeatherRepository>();
            services.HttpCommunicationIoC();
        }
    }
}