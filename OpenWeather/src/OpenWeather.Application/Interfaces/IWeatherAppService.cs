namespace OpenWeather.Application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using OpenWeather.Application.ViewModels;

    public interface IWeatherAppService : IDisposable
    {
        Task Add(WeatherViewModel weatherViewModel);

        Task<IEnumerable<WeatherViewModel>> GetByCitiesAndTimeInterval(string[] cities, DateTime? starTime, DateTime? endTime);
    }
}