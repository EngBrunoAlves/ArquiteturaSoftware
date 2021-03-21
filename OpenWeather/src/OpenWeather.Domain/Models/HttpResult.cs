namespace OpenWeather.Domain.Models
{
    using System.Net;
    using System.Net.Http.Headers;

    public class HttpResult<T>
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public T Content { get; set; }
        public string RequestMessage { get; set; }
        public HttpRequestHeaders Headers { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public string Error { get; set; }
    }
}