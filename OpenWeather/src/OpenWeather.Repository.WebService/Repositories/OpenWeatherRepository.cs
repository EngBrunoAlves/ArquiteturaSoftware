namespace OpenWeather.Repository.WebService.Repositories
{
    using Microsoft.Extensions.Options;
    using OpenWeather.Domain.Interfaces.Integrations;
    using OpenWeather.Domain.Interfaces.Repositories;
    using OpenWeather.Domain.Models;
    using OpenWeather.Repository.WebService.Helper;
    using OpenWeather.Repository.WebService.Models;
    using System.Net.Http;
    using System.Threading.Tasks;

    internal class OpenWeatherRepository : IOpenWeatherRepository
    {
        private readonly IHttpCommunication httpCommunication;
        private readonly OpenWeatherOptions options;

        public OpenWeatherRepository(IOptions<OpenWeatherOptions> options, IHttpCommunication httpCommunication)
        {
            this.httpCommunication = httpCommunication;
            this.options = options.Value;
        }

        public async Task<double> GetTemperatureByCity(string city)
        {
            var url = string.Format(options.OpenWeatherUrlBase, city, options.OpenWeatherToken);
            var result = await httpCommunication.GetAsync<OpenWeatherResult>(url);

            if(!result.IsSuccessStatusCode || result.Content?.Main is null)
                throw new HttpRequestException("The endpoint didn't return a valid value");
            
            var kelvinTemperature = result.Content.Main.Temp;

            return TemperatureConverter.KelvinToCelsius(kelvinTemperature);
        }

        public void Dispose()
        {
            httpCommunication?.Dispose();
        }
    }
}