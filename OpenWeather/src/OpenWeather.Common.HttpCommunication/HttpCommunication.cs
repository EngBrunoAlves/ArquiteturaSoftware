namespace OpenWeather.Common.HttpCommunication
{
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using OpenWeather.Domain.Interfaces.Integrations;
    using OpenWeather.Domain.Models;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    internal class HttpCommunication : IHttpCommunication
    {
        private readonly HttpClient httpClient;
        private readonly OpenWeatherOptions options;

        public HttpCommunication(HttpClient httpClient, IOptions<OpenWeatherOptions> options)
        {
            this.httpClient = httpClient;
            this.options = options.Value;
        }

        public async Task<HttpResult<TOut>> PostAsync<TOut>(string url, object entity, HttpCustomOptions customOptions = null, int tryAgainTimes = 0)
        {
            var content = GetContent(entity);
            var response = await httpClient.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
            if (TryAgain(customOptions, response, tryAgainTimes))
                return await PostAsync<TOut>(url, entity, customOptions, tryAgainTimes + 1);
            return await response.ConvertResponse<TOut>();
        }

        public async Task<HttpResult<TOut>> GetAsync<TOut>(string url, HttpCustomOptions customOptions = null, int tryAgainTimes = 0)
        {
            var response = await httpClient.GetAsync(url);
            if (TryAgain(customOptions, response, tryAgainTimes))
                return await GetAsync<TOut>(url, customOptions, tryAgainTimes + 1);
            return await response.ConvertResponse<TOut>();
        }

        public async Task<HttpResult<TOut>> PutAsync<TOut>(string url, object entity, HttpCustomOptions customOptions = null, int tryAgainTimes = 0)
        {
            var content = GetContent(entity);
            var response = await httpClient.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json"));
            if (TryAgain(customOptions, response, tryAgainTimes))
                return await PutAsync<TOut>(url, entity, customOptions, tryAgainTimes + 1);
            return await response.ConvertResponse<TOut>();
        }

        public async Task<HttpResult<TOut>> DeleteAsync<TOut>(string url, HttpCustomOptions customOptions = null, int tryAgainTimes = 0)
        {
            var response = await httpClient.DeleteAsync(url);
            if (TryAgain(customOptions, response, tryAgainTimes))
                return await DeleteAsync<TOut>(url, customOptions, tryAgainTimes + 1);
            return await response.ConvertResponse<TOut>();
        }

        private bool TryAgain(HttpCustomOptions customOptions, HttpResponseMessage response, int tryAgainTimes) =>
            (customOptions?.ExecuteRetry ?? true) && response.StatusCode != HttpStatusCode.OK && tryAgainTimes < options.HttpNumberTimesOfTryAgain;

        private static string GetContent(object entity) =>
            entity is null ? string.Empty : JsonConvert.SerializeObject(entity);
        

        public void Dispose()
        {
            httpClient?.Dispose();
        }
    }
}