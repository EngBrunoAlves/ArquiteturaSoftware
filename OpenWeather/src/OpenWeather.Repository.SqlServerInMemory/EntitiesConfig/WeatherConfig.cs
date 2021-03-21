namespace OpenWeather.Repository.SqlServerInMemory.EntitiesConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OpenWeather.Domain.Entities;

    public class WeatherConfig : IEntityTypeConfiguration<Weather>
    {
        public void Configure(EntityTypeBuilder<Weather> builder)
        {
            builder
                .Property(c => c.City)
                .IsRequired()
                .HasMaxLength(8000);

            builder
                .Property(c => c.CreatedDate)
                .IsRequired();

            builder
                .Property(c => c.Temperature)
                .IsRequired();

            builder
                .ToTable("Weather");
        }
    }
}