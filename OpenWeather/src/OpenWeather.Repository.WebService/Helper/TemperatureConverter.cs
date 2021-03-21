namespace OpenWeather.Repository.WebService.Helper
{
    internal static class TemperatureConverter
    {
        public static double KelvinToCelsius(double value) => value - 273;
    }
}