using BillsToPay.Domain.Entities;
using BillsToPay.Domain.Interfaces.Repositories;
using BillsToPay.Repository.MongoDb.Context;

namespace BillsToPay.Repository.MongoDb.Repositories
{
	internal sealed class LateFeeRepository : RepositoryBase<LateFee>, ILateFeeRepository
	{
		public LateFeeRepository(BillsToPayContext context) : base(context)
		{
		}
	}
}
