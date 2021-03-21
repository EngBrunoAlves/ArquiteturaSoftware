namespace OpenWeather.Domain.Interfaces.Repositories
{
    using OpenWeather.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWeatherRepository : IRepositoryBase<Weather>
    {
        Task<IEnumerable<Weather>> GetByCitiesAndTimeInterval(string[] cities, DateTime starTime, DateTime endTime);
    }
}