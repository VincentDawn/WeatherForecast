using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using WeatherForecast.Helpers;
using WeatherForecast.Models.MetaweatherModels;

namespace WeatherForecastApp.Tests
{
    public class MetaweatherHelperTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<HttpClient> _mockHttpClient;

        public MetaweatherHelperTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockHttpClient = new Mock<HttpClient>();
        }

        [Fact]
        public void Location_ReturnsExpectedLocationResponseObject()
        {
            // Arrange
            var testWoeid = 123;
            var expectedResponse = new LocationResponseObject();
            _mockConfiguration.Setup(c => c.GetSection("Metaweather").GetSection("APIURL").Value).Returns("http://testurl.com/");
            _mockConfiguration.Setup(c => c.GetSection("Metaweather").GetSection("LocationEndpoint").Value).Returns("location/");
            _mockHttpClient.Setup(h => h.SendAsync(It.IsAny<HttpRequestMessage>()).Result.Content.ReadAsStringAsync().Result).Returns(JsonConvert.SerializeObject(expectedResponse));

            var helper = new MetaweatherHelper(_mockConfiguration.Object, _mockHttpClient.Object);

            // Act
            var result = helper.Location(testWoeid);

            // Assert
            Assert.Equal(expectedResponse, result);
        }
    }
}
