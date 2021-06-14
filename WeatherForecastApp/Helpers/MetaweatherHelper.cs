using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using WeatherForecast.Interfaces;
using WeatherForecast.Models.MetaweatherModels;

namespace WeatherForecast.Helpers
{
    public class MetaweatherHelper : IMetaweatherHelper
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public MetaweatherHelper(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }
        public LocationResponseObject Location(int woeid)
        {
            string apiUrl = _configuration.GetSection("Metaweather").GetSection("APIURL").Value;
            string apiEndpoint = _configuration.GetSection("Metaweather").GetSection("LocationEndpoint").Value;

            string url = apiUrl + apiEndpoint + woeid;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            return JsonConvert.DeserializeObject<LocationResponseObject>(_httpClient.SendAsync(httpRequestMessage).Result.Content.ReadAsStringAsync().Result);
        }
    }
}
