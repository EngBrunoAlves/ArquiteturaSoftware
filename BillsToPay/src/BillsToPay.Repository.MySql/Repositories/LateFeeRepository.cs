namespace BillsToPay.Repository.MySql.Repositories
{
	using BillsToPay.Domain.Entities;
	using BillsToPay.Domain.Interfaces.Repositories;
	using BillsToPay.Repository.MySql.Context;

	internal sealed class LateFeeRepository : RepositoryBase<LateFee>, ILateFeeRepository
	{
		public LateFeeRepository(BillsToPayContext context) : base(context) { }
	}
}