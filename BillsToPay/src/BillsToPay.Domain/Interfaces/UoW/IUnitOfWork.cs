namespace BillsToPay.Domain.Interfaces.UoW
{
    using BillsToPay.Domain.Interfaces.Repositories;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        void BeginTransaction();
        bool HasCurrentTransaction();
        Task Commit();
        void Rollback();

        IBillToPayRepository BillsToPay { get; }
        ILateFeeRepository LateFees { get; }
    }
}