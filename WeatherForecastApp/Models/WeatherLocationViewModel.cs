using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherForecast.Models
{
    public class WeatherLocationViewModel
    {
        [Display(Name = "Weather State")]
        public string WeatherStateName { get; set; }
        public string WeatherStateAbbreviation { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Display(Name = "Date Updated")]
        public DateTime DateUpdated { get; set; }
        [Display(Name = "Date For")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ApplicableDate { get; set; }
        [Display(Name = "Min Temp")]
        public float MinTemp { get; set; }
        [Display(Name = "Max Temp")]
        public float MaxTemp { get; set; }
        [Display(Name = "Current Temp")]
        public float CurrentTemp { get; set; }
        [Display(Name = "Wind Speed")]
        public float WindSpeed { get; set; }
        [Display(Name = "Humidity")]
        public float Humidity { get; set; }
    }
}
