namespace OpenWeather.Domain.Services
{
    using OpenWeather.Domain.BusinessRules.Base;
    using OpenWeather.Domain.Entities;
    using OpenWeather.Domain.Exceptions;
    using OpenWeather.Domain.Interfaces.Services;
    using OpenWeather.Domain.Interfaces.UoW;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class WeatherService : IWeatherService
    {
        private readonly IUnitOfWork uow;

        public WeatherService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async  Task Add(Weather weather)
        {
            if (!ModelIsValid.Execute(weather, out var results))
                throw new ModelIsNotValidException($"Errors found: {string.Join("; ", results.Select(x => x.ErrorMessage))}.");

            weather.City = weather.City.ToLower();

            await uow.Wheaters.Add(weather);
        }

        public async Task<IEnumerable<Weather>> GetByCitiesAndTimeInterval(string[] cities, DateTime? starTime, DateTime? endTime)
        {
            if(!starTime.HasValue)
                throw new ArgumentNullException(nameof(starTime));

            if(!endTime.HasValue)
                throw new ArgumentNullException(nameof(endTime));

            if (!DateIntervalIsValid.Execute(starTime, endTime))
                throw new DateIntervalIsNotValidException($"The interval {starTime} and {endTime} is not valid");

            if(cities is null || !cities.Any())
                throw new ArgumentNullException(nameof(cities));

            cities = cities.Select(c => c.ToLower()).ToArray();

            return await uow.Wheaters.GetByCitiesAndTimeInterval(cities, starTime.Value, endTime.Value);
        }

        public void Dispose()
        {
            uow?.Dispose();
        }
    }
}