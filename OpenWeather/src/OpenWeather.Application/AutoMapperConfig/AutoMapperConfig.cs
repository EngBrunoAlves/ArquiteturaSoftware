namespace OpenWeather.Application.AutoMapperConfig
{
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using OpenWeather.Application.ViewModels;
    using OpenWeather.Domain.Entities;

    internal static class AutoMapperConfig
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Weather, WeatherViewModel>().ReverseMap();
            });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}