namespace OpenWeather.Domain.Interfaces.Repositories
{
    using System;
    using System.Threading.Tasks;

    public interface IOpenWeatherRepository : IDisposable
    {
        Task<double> GetTemperatureByCity(string city);
    }
}