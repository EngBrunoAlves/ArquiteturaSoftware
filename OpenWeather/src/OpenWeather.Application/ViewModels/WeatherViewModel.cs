namespace OpenWeather.Application.ViewModels
{
    using System;

    public class WeatherViewModel
    {
        public long Id { get; set; }

        public string City { get; set; }

        public double? Temperature { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}