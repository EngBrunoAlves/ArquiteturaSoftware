namespace OpenWeather.Domain.IoC
{
    using Microsoft.Extensions.DependencyInjection;
    using OpenWeather.Domain.Interfaces.Services;
    using OpenWeather.Domain.Services;

    public static class IoC
    {
        public static void DomainIoC(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();
            services.AddScoped<IOpenWeatherService, OpenWeatherService>();
        }
    }
}