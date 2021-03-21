namespace OpenWeather.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Weather : EntityBase
    {
        [Required]
        public string City { get; set; }

        [Required]
        public double? Temperature { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }
    }
}