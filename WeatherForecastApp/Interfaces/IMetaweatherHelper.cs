using WeatherForecast.Models.MetaweatherModels;

namespace WeatherForecast.Interfaces
{
    public interface IMetaweatherHelper
    {
        public LocationResponseObject Location(int woeid);
    }
}