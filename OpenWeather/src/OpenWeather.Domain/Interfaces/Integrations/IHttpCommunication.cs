namespace OpenWeather.Domain.Interfaces.Integrations
{
    using System;
    using System.Threading.Tasks;
    using OpenWeather.Domain.Models;

    public interface IHttpCommunication : IDisposable
    {
        Task<HttpResult<TOut>> DeleteAsync<TOut>(string url, HttpCustomOptions customOptions = null, int tryAgainTimes = 0);
        Task<HttpResult<TOut>> GetAsync<TOut>(string url, HttpCustomOptions customOptions = null, int tryAgainTimes = 0);
        Task<HttpResult<TOut>> PostAsync<TOut>(string url, object entity, HttpCustomOptions customOptions = null, int tryAgainTimes = 0);
        Task<HttpResult<TOut>> PutAsync<TOut>(string url, object entity, HttpCustomOptions customOptions = null, int tryAgainTimes = 0);
    }
}