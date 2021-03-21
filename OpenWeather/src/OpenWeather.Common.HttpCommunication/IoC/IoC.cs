namespace OpenWeather.Common.HttpCommunication.IoC
{
    using Microsoft.Extensions.DependencyInjection;
    using OpenWeather.Domain.Interfaces.Integrations;

    public static class IoC
    {
        public static void HttpCommunicationIoC(this IServiceCollection services)
        {
            services.AddScoped<IHttpCommunication, HttpCommunication>();
            services.AddHttpClient<IHttpCommunication, HttpCommunication>();
        }
    }
}