namespace OpenWeather.Application.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IOpenWeatherAppService : IDisposable
    {
        Task PopulateCitTemperature(string city);
    }
}