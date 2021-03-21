namespace OpenWeather.Application.IoC
{
    using Microsoft.Extensions.DependencyInjection;
    using OpenWeather.Application.AppServices;
    using OpenWeather.Application.AutoMapperConfig;
    using OpenWeather.Application.Interfaces;

    public static class IoC
    {
        public static void ApplicationIoC(this IServiceCollection services)
        {
            services.RegisterMappings();
            services.AddScoped<IWeatherAppService, WeatherAppService>();
            services.AddScoped<IOpenWeatherAppService, OpenWeatherAppService>();
        }
    }
}