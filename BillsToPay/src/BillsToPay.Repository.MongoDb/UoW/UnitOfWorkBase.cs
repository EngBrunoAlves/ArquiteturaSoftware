using BillsToPay.Domain.Interfaces.Repositories;

namespace BillsToPay.Repository.MongoDb.UoW
{
	internal abstract class UnitOfWorkBase
	{
		protected IBillToPayRepository _billToPayRepository;
		protected ILateFeeRepository _lateFeeRepository;
	}
}
