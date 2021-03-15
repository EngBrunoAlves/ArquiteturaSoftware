namespace DemoAcmeAp.Repository.SqlServerInMemory.UoW
{
    using DemoAcmeAp.Domain.Interfaces.Repositories;

    internal abstract class UnitOfWorkBase
    {
        protected IClienteRepository _clienteRepository;
        protected IFaturaRepository _faturaRepository;
        protected IInstalacaoRepository _instalacaoRepository;
    }
}