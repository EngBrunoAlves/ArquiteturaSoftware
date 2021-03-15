namespace DemoAcmeAp.Repository.SqlServerInMemory.UoW
{
    using DemoAcmeAp.Domain.Interfaces.Repositories;
    using DemoAcmeAp.Domain.Interfaces.UoW;
    using DemoAcmeAp.Repository.SqlServerInMemory.Context;
    using DemoAcmeAp.Repository.SqlServerInMemory.Repositories;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Threading.Tasks;

    internal sealed class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        #region Constructor
        private readonly DemoAcmeApContext _context;

        private IDbContextTransaction transaction = null;

        public UnitOfWork(DemoAcmeApContext context)
        {
            _context = context;
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

        public IClienteRepository Clientes => _clienteRepository ??= new ClienteRepository(_context);

        public IFaturaRepository Faturas => _faturaRepository ??= new FaturaRepository(_context);

        public IInstalacaoRepository Instalacoes => _instalacaoRepository ??= new InstalacaoRepository(_context);

        private void DisposeRepositories()
        {
            _clienteRepository?.Dispose(); _clienteRepository = null;
            _faturaRepository?.Dispose(); _faturaRepository = null;
            _instalacaoRepository?.Dispose(); _instalacaoRepository = null;
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