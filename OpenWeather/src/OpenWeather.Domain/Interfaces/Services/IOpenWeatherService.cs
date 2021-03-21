namespace OpenWeather.Domain.Interfaces.Services
{
    using OpenWeather.Domain.Entities;
    using System;
    using System.Threading.Tasks;

    public interface IOpenWeatherService : IDisposable
    {
        Task<Weather> GetWeatherByCity(string city);
    }
}