namespace BillsToPay.Repository.MySql.UoW
{
    using BillsToPay.Domain.Interfaces.Repositories;

    internal abstract class UnitOfWorkBase
    {
        protected IBillToPayRepository _billToPayRepository;
    }
}