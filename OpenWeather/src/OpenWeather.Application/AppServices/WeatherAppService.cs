namespace OpenWeather.Application.AppServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using OpenWeather.Application.AppServices.Base;
    using OpenWeather.Application.Interfaces;
    using OpenWeather.Application.ViewModels;
    using OpenWeather.Domain.Entities;
    using OpenWeather.Domain.Interfaces.Services;
    using OpenWeather.Domain.Interfaces.UoW;

    internal class WeatherAppService : AppServiceBase, IWeatherAppService
    {
        private readonly IWeatherService weatherService;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public WeatherAppService(IWeatherService weatherService, IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            this.weatherService = weatherService;
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task Add(WeatherViewModel weatherViewModel)
        {
            var weather = mapper.Map<Weather>(weatherViewModel);

            BeginTransaction();
            await weatherService.Add(weather);
            Commit();
        }

        public async Task<IEnumerable<WeatherViewModel>> GetByCitiesAndTimeInterval(string[] cities, DateTime? starTime, DateTime? endTime)
        {
            var result = await weatherService.GetByCitiesAndTimeInterval(cities, starTime, endTime);

            return result
                .Select(w => mapper.Map<WeatherViewModel>(w))
                .ToList();
        }

        public void Dispose()
        {
            weatherService?.Dispose();
            uow?.Dispose();
        }
    }
}