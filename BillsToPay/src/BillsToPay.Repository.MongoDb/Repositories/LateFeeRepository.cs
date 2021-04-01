namespace BillsToPay.Repository.MongoDb.Repositories
{
    using BillsToPay.Domain.Entities;
    using BillsToPay.Domain.Interfaces.Repositories;
    using BillsToPay.Repository.MongoDb.Context;

    internal sealed class LateFeeRepository : RepositoryBase<LateFee>, ILateFeeRepository
    {
        public LateFeeRepository(BillsToPayContext context) : base(context)
        {
        }
    }
}
