using Xunit;
using NSubstitute;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using WeatherForecast.Helpers;
using WeatherForecast.Models.MetaweatherModels;

namespace WeatherForecastApp.Tests
{
    public class MetaweatherHelperTests
    {
        private readonly IConfiguration _mockConfiguration;
        private readonly HttpClient _mockHttpClient;

        public MetaweatherHelperTests()
        {
            _mockConfiguration = Substitute.For<IConfiguration>();
            _mockHttpClient = Substitute.For<HttpClient>();
        }

        [Fact]
        public void Location_ReturnsLocationResponseObject_WhenCalledWithValidWoeid()
        {
            // Arrange
            var testWoeid = 123;
            var expectedResponse = new LocationResponseObject();
            _mockConfiguration.GetSection("Metaweather").GetSection("APIURL").Value.Returns("http://testurl.com/");
            _mockConfiguration.GetSection("Metaweather").GetSection("LocationEndpoint").Value.Returns("location/");
            _mockHttpClient.SendAsync(Arg.Any<HttpRequestMessage>()).Returns(Task.FromResult(new HttpResponseMessage { Content = new StringContent(JsonConvert.SerializeObject(expectedResponse)) }));

            var helper = new MetaweatherHelper(_mockConfiguration.Object, _mockHttpClient.Object);

            // Act
            var result = helper.Location(testWoeid);

            // Assert
            Assert.Equal(expectedResponse, result);
        }
    }
}
