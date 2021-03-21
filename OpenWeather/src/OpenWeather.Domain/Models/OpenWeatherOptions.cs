namespace OpenWeather.Domain.Models
{
    public class OpenWeatherOptions
    {
        public int CheckUpdateTimeSeconds { get; set; }
        public string[] CitiesToGetTemperature { get; set; }
        public string OpenWeatherUrlBase { get; set; }
        public string OpenWeatherToken { get; set; }
        public int HttpNumberTimesOfTryAgain { get; set; }
    }
}