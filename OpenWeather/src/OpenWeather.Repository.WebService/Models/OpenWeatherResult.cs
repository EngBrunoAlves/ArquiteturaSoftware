namespace OpenWeather.Repository.WebService.Models
{
    internal class OpenWeatherResult
    {
        public OpenWeatherResultMain Main { get; set; }
    }

    internal class OpenWeatherResultMain
    {
        public double Temp { get; set; }
    }
}