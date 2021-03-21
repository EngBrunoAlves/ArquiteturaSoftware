namespace OpenWeather.Application.AppServices
{
    using OpenWeather.Application.AppServices.Base;
    using OpenWeather.Application.Interfaces;
    using OpenWeather.Domain.Interfaces.Services;
    using OpenWeather.Domain.Interfaces.UoW;
    using System.Threading.Tasks;

    internal class OpenWeatherAppService : AppServiceBase, IOpenWeatherAppService
    {
        private readonly IOpenWeatherService service;
        private readonly IWeatherService weatherService;

        public OpenWeatherAppService(IOpenWeatherService service, IWeatherService weatherService, IUnitOfWork uow) : base(uow)
        {
            this.service = service;
            this.weatherService = weatherService;
        }

        public async Task PopulateCitTemperature(string city)
        {
            var weather = await service.GetWeatherByCity(city);
            
            BeginTransaction();
            await weatherService.Add(weather);
            Commit();
        }

        public void Dispose()
        {
            service?.Dispose();
            weatherService?.Dispose();
        }
    }
}