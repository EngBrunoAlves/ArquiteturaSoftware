namespace OpenWeather.Repository.SqlServerInMemory.IoC
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using OpenWeather.Domain.Interfaces.UoW;
    using OpenWeather.Repository.SqlServerInMemory.Context;
    using OpenWeather.Repository.SqlServerInMemory.UoW;

    public static class IoC
    {
        public static void SqlServerInMemoryRepositoryIoC(this IServiceCollection services)
        {
            services.AddDbContext<OpenWeatherDbContext>(opt => opt.UseInMemoryDatabase("OpenWeatherDb"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}