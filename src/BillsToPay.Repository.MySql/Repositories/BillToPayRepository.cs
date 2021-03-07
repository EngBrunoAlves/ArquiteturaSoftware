namespace BillsToPay.Repository.MySql.Repositories
{
    using System;
    using BillsToPay.Domain.Entities;
    using BillsToPay.Domain.Interfaces.Repositories;
    using BillsToPay.Repository.MySql.Context;

    internal class BillToPayRepository : RepositoryBase<BillToPay>, IBillToPayRepository
    {
        public BillToPayRepository(BillsToPayContext context) : base(context) { }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}