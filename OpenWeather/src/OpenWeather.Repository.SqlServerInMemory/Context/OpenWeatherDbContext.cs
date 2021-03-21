namespace OpenWeather.Repository.SqlServerInMemory.Context
{
    using Microsoft.EntityFrameworkCore;
    using OpenWeather.Domain.Entities;
    using OpenWeather.Repository.SqlServerInMemory.EntitiesConfig;

    public class OpenWeatherDbContext : DbContext
    {
        public OpenWeatherDbContext(DbContextOptions<OpenWeatherDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WeatherConfig());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Weather> Weather { get; set; }
    }
}