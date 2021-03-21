namespace OpenWeather.Domain.Services
{
    using System;
    using OpenWeather.Domain.Interfaces.Repositories;
    using OpenWeather.Domain.Interfaces.Services;
    using System.Threading.Tasks;
    using OpenWeather.Domain.Entities;

    internal class OpenWeatherService : IOpenWeatherService
    {
        private readonly IOpenWeatherRepository repository;

        public OpenWeatherService(IOpenWeatherRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Weather> GetWeatherByCity(string city)
        {
            var temperature = await repository.GetTemperatureByCity(city);

            return new Weather
            {
                City = city,
                Temperature = temperature,
                CreatedDate = DateTime.UtcNow
            };
        }

        public void Dispose()
        {
            repository?.Dispose();
        }
    }
}