using BillsToPay.Domain.Interfaces.Repositories;
using BillsToPay.Domain.Interfaces.UoW;
using BillsToPay.Repository.MongoDb.Context;
using BillsToPay.Repository.MongoDb.Repositories;
using System.Threading.Tasks;

namespace BillsToPay.Repository.MongoDb.UoW
{
	internal sealed class UnitOfWork : UnitOfWorkBase, IUnitOfWork
	{
		#region Constructor
		private readonly BillsToPayContext _context;

		public UnitOfWork(BillsToPayContext context)
		{
			_context = context;
		}
        #endregion

        #region Transaction
        public void BeginTransaction()
        {
            //nop
        }

        public bool HasCurrentTransaction()
        {
            return false;
        }

        public async Task Commit()
        {
            //nop
        }

        public void Rollback()
        {
            //nop
        }
        #endregion

        public IBillToPayRepository BillsToPay => _billToPayRepository ??= new BillToPayRepository(_context);

        public ILateFeeRepository LateFees => _lateFeeRepository ??= new LateFeeRepository(_context);

        private void DisposeRepositories()
        {
            _billToPayRepository?.Dispose(); _billToPayRepository = null;
            _lateFeeRepository?.Dispose(); _lateFeeRepository = null;
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
