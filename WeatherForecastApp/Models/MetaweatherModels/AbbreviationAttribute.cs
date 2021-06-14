using System;

namespace WeatherForecast.Models.MetaweatherModels
{
    internal class AbbreviationAttribute : Attribute
    {
        public string Name { get; set; }
    }
}