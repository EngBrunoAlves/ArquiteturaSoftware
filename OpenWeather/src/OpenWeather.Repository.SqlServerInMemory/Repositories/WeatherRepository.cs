namespace OpenWeather.Repository.SqlServerInMemory.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using OpenWeather.Domain.Entities;
    using OpenWeather.Domain.Interfaces.Repositories;
    using OpenWeather.Repository.SqlServerInMemory.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class WeatherRepository : RepositoryBase<Weather>, IWeatherRepository
    {
        public WeatherRepository(OpenWeatherDbContext context) : base(context) { }

        public async Task<IEnumerable<Weather>> GetByCitiesAndTimeInterval(string[] cities, DateTime starTime, DateTime endTime)
        {
            return await DbSet
                .Where(w => cities.Any(c => c.Equals(w.City)))
                .Where(w => w.CreatedDate >= starTime)
                .Where(w => w.CreatedDate <= endTime)
                .ToListAsync();
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}