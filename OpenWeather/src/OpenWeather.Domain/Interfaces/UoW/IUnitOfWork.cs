namespace OpenWeather.Domain.Interfaces.UoW
{
    using System;
    using OpenWeather.Domain.Interfaces.Repositories;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        bool HasCurrentTransaction();
        Task Commit();
        void Rollback();

        IWeatherRepository Wheaters { get; }

    }
}