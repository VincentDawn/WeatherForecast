using System;
using System.Collections.Generic;

namespace WeatherForecast.Models.MetaweatherModels
{
    public class LocationResponseObject
    {
        public string title { get; set; }
        public string location_type { get; set; }
        public string latt_long { get; set; }
        public DateTime time { get; set; }
        public DateTime sun_rise { get; set; }
        public DateTime sun_set { get; set; }
        public string timezone_name { get; set; }
        public IEnumerable<ConsolidatedWeather> consolidated_weather { get; set; }
        public Parent parent { get; set; }
        public IEnumerable<Source> sources { get; set; }
    }
}
