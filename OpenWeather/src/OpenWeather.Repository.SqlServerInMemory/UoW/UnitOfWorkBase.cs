namespace OpenWeather.Repository.SqlServerInMemory.UoW
{
    using OpenWeather.Domain.Interfaces.Repositories;

    internal abstract class UnitOfWorkBase
    {
        protected IWeatherRepository _weatherRepository;
    }
}