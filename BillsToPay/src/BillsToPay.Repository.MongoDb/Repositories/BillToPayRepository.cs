namespace BillsToPay.Repository.MongoDb.Repositories
{
    using BillsToPay.Domain.Entities;
    using BillsToPay.Domain.Interfaces.Repositories;
    using BillsToPay.Repository.MongoDb.Context;

    internal sealed class BillToPayRepository : RepositoryBase<BillToPay>, IBillToPayRepository
    {
        public BillToPayRepository(BillsToPayContext context) : base(context)
        {
        }
    }
}
