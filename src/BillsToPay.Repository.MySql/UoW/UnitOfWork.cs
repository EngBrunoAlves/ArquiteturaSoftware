namespace BillsToPay.Repository.MySql.UoW
{
    using BillsToPay.Domain.Interfaces.Repositories;
    using BillsToPay.Domain.Interfaces.UoW;
    using BillsToPay.Repository.MySql.Context;
    using BillsToPay.Repository.MySql.Repositories;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Threading.Tasks;
    using BillsToPay.Repository.MySql.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    internal sealed class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        #region Constructor
        private readonly BillsToPayContext _context;

        private IDbContextTransaction transaction = null;

        public UnitOfWork(IOptions<BillsToPayOptions> options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BillsToPayContext>();
            optionsBuilder.UseMySql(options?.Value.ConnectionString ?? throw new ArgumentNullException(nameof(options)));
            _context = new BillsToPayContext(optionsBuilder.Options);
        }
        #endregion

        #region Transaction
        public void BeginTransaction()
        {
            transaction = _context.Database.BeginTransaction();
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

        public IBillToPayRepository BillsToPay => _billToPayRepository ??= new BillToPayRepository(_context);

        private void DisposeRepositories()
        {
            _billToPayRepository?.Dispose(); _billToPayRepository = null;
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