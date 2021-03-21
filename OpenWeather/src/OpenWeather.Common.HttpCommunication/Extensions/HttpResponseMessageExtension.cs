namespace System.Net.Http
{
    using Newtonsoft.Json;
    using OpenWeather.Domain.Models;
    using System.Threading.Tasks;

    internal static class HttpResponseMessageExtension
    {
        public static async Task<HttpResult<T>> ConvertResponse<T>(this HttpResponseMessage message) =>
            new HttpResult<T>
            {
                HttpStatusCode = message.StatusCode,
                Content = message.Content != null && message.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(await message.Content.ReadAsStringAsync()) : default(T),
                RequestMessage = message.RequestMessage.Content != null ? await message.RequestMessage.Content.ReadAsStringAsync() : string.Empty,
                Headers = message.RequestMessage?.Headers,
                IsSuccessStatusCode = message.IsSuccessStatusCode,
                Error = !message.IsSuccessStatusCode ? await TryGetErrorMessage(message) : string.Empty
            };

        private static async Task<string> TryGetErrorMessage(HttpResponseMessage message)
        {
            try
            {
                var result = await message.Content.ReadAsStringAsync();
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}