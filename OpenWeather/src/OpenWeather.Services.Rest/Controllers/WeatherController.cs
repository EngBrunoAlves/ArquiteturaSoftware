namespace OpenWeather.Services.Rest.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using OpenWeather.Application.Interfaces;
    using OpenWeather.Application.ViewModels;

    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase, IDisposable
    {
        private readonly IWeatherAppService appService;

        public WeatherController(IWeatherAppService appService)
        {
            this.appService = appService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherViewModel>> GetCity([FromQuery] string[] cities, [FromQuery] DateTime? startTime, [FromQuery] DateTime? endTime)
        {
            return await appService.GetByCitiesAndTimeInterval(cities, startTime, endTime);
        }

        public void Dispose()
        {
            appService?.Dispose();
        }
    }
}
