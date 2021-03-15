namespace DemoAcmeAp.Domain.Interfaces.UoW
{
    using System.Threading.Tasks;
    using DemoAcmeAp.Domain.Interfaces.Repositories;

    public interface IUnitOfWork
    {
        void BeginTransaction();
        bool HasCurrentTransaction();
        Task Commit();
        void Rollback();

        IClienteRepository Clientes { get; }
        IFaturaRepository Faturas { get; }
        IInstalacaoRepository Instalacoes { get; }
    }
}