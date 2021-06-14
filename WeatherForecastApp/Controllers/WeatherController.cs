using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherForecast.Interfaces;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    [Authorize]
    public class WeatherController : Controller
    {
        private readonly IMetaweatherHelper _metaweatherHelper;
        private readonly IConfiguration _configuration;

        public WeatherController(IMetaweatherHelper metaweatherHelper, IConfiguration configuration)
        {
            _metaweatherHelper = metaweatherHelper;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index(int? woeid)
        {
            // Weather view model
            if (!woeid.HasValue)
            {
                woeid = Convert.ToInt32(_configuration.GetSection("Metaweather").GetSection("WhereOnEarthIDs").GetSection("Belfast").Value);
            }

            // Hit the API, get some info
            var response = _metaweatherHelper.Location(woeid.Value);

            // Ignore the first/current day
            response.consolidated_weather = response.consolidated_weather.OrderBy(x => x.applicable_date).TakeLast(5);

            // Image base path
            string imageBasePath = $"{_configuration.GetSection("Metaweather").GetSection("MetaweatherURL").Value}" +
                $"{_configuration.GetSection("Metaweather").GetSection("ImagePath").Value}";

            // Convert it to view models
            WeatherViewModel weatherViewModel = new WeatherViewModel()
            {
                DateUpdated = response.time,
                LocationName = response.title,
                ParentLocationName = response.parent.title,
                weatherLocationViewModels = response.consolidated_weather.Select(x => new WeatherLocationViewModel()
                {
                    ApplicableDate = x.applicable_date,
                    CurrentTemp = x.the_temp,
                    DateUpdated = response.time,
                    Humidity = x.humidity,
                    ImageUrl = imageBasePath + x.weather_state_abbr + ".svg",
                    MaxTemp = x.max_temp,
                    MinTemp = x.min_temp,
                    WeatherStateName = x.weather_state_name,
                    WeatherStateAbbreviation = x.weather_state_abbr,
                    WindSpeed = x.wind_speed
                }).ToList(),
                Woeid = woeid.Value
            };

            return View(weatherViewModel);
        }

        [HttpGet]
        public IActionResult GetWeatherForecast(int woeid)
        {
            // Hit the API, get some info
            var response = _metaweatherHelper.Location(woeid);

            // Ignore the first/current day
            response.consolidated_weather = response.consolidated_weather.OrderBy(x => x.applicable_date).TakeLast(5);

            // Image base path
            string imageBasePath = $"{_configuration.GetSection("Metaweather").GetSection("MetaweatherURL").Value}" +
                $"{_configuration.GetSection("Metaweather").GetSection("ImagePath").Value}";

            // Convert it to view models
            List<WeatherLocationViewModel> weatherLocationViewModels = response.consolidated_weather.Select(x => new WeatherLocationViewModel()
            {
                ApplicableDate = x.applicable_date,
                CurrentTemp = x.the_temp,
                DateUpdated = response.time,
                Humidity = x.humidity,
                ImageUrl = imageBasePath + x.weather_state_abbr + ".svg",
                MaxTemp = x.max_temp,
                MinTemp = x.min_temp,
                WeatherStateName = x.weather_state_name,
                WeatherStateAbbreviation = x.weather_state_abbr,
                WindSpeed = x.wind_speed
            }).ToList();

            // Return partial
            return PartialView("_WeatherLocations", weatherLocationViewModels);
        }
    }
}
