using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WeatherForecast.Data
{
    public class WeatherForecastDBContext : IdentityDbContext
    {
        public WeatherForecastDBContext(DbContextOptions<WeatherForecastDBContext> options)
            : base(options)
        {
        }
    }
}
