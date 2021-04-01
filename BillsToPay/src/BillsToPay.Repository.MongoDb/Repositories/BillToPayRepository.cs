using BillsToPay.Domain.Entities;
using BillsToPay.Domain.Interfaces.Repositories;
using BillsToPay.Repository.MongoDb.Context;

namespace BillsToPay.Repository.MongoDb.Repositories
{
	internal sealed class BillToPayRepository : RepositoryBase<BillToPay>, IBillToPayRepository
	{
		public BillToPayRepository(BillsToPayContext context) : base(context)
		{
		}
	}
}
