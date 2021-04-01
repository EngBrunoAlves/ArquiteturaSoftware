namespace BillsToPay.Repository.MySql.Repositories
{
	using BillsToPay.Domain.Entities;
	using BillsToPay.Domain.Interfaces.Repositories;
	using BillsToPay.Repository.MySql.Context;

	internal sealed class BillToPayRepository : RepositoryBase<BillToPay>, IBillToPayRepository
    {
        public BillToPayRepository(BillsToPayContext context) : base(context) { }
    }
}