namespace OpenWeather.Domain.Models
{
    using System.Net.Http.Headers;

    public class HttpCustomOptions
    {
        public AuthenticationHeaderValue Authentication { get; set; }
        public HttpCustomHeader CustomHeader { get; set; }
        public bool ExecuteRetry { get; set; }
    }
}