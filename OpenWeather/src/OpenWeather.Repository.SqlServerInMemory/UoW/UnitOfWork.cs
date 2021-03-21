namespace OpenWeather.Repository.SqlServerInMemory.UoW
{
    using Microsoft.EntityFrameworkCore.Storage;
    using OpenWeather.Domain.Interfaces.Repositories;
    using OpenWeather.Domain.Interfaces.UoW;
    using OpenWeather.Repository.SqlServerInMemory.Context;
    using OpenWeather.Repository.SqlServerInMemory.Repositories;
    using System;
    using System.Threading.Tasks;

    internal class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        #region Constructor
        private readonly OpenWeatherDbContext _context;

        private IDbContextTransaction transaction = null;

        public UnitOfWork(OpenWeatherDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Transaction
        //Disabled because SqlServer InMemory don't implement transactions
        public void BeginTransaction()
        {
            //transaction = _context.Database.BeginTransaction();
        }

        public bool HasCurrentTransaction()
        {
            return _context.Database.CurrentTransaction != null;
        }

        public async Task Commit()
        {
            try
            {
                await _context.SaveChangesAsync();
                transaction?.Commit();
            }
            catch (Exception)
            {
                transaction?.Rollback();
                throw;
            }
            finally
            {
                transaction = null;
            }
        }

        public void Rollback()
        {
            try
            {
                transaction.Rollback();
            }
            finally
            {
                transaction = null;
            }
        }
        #endregion

        public IWeatherRepository Wheaters => _weatherRepository ??= new WeatherRepository(_context);

        private void DisposeRepositories()
        {
            _weatherRepository?.Dispose(); _weatherRepository = null;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                DisposeRepositories();
                disposedValue = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}