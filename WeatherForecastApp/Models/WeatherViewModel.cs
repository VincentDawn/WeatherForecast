using System;
using System.Collections.Generic;

namespace WeatherForecast.Models
{
    public class WeatherViewModel
    {
        public int Woeid { get; set; }
        public string LocationName { get; set; }
        public string ParentLocationName { get; set; }
        public DateTime DateUpdated { get; set; }
        public List<WeatherLocationViewModel> weatherLocationViewModels { get; set; }
    }
}
