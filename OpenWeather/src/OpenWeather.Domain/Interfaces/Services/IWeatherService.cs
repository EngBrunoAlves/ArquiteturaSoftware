namespace OpenWeather.Domain.Interfaces.Services
{
    using OpenWeather.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWeatherService : IDisposable
    {
        Task Add(Weather weather);

        Task<IEnumerable<Weather>> GetByCitiesAndTimeInterval(string[] cities, DateTime? starTime, DateTime? endTime);
    }
}