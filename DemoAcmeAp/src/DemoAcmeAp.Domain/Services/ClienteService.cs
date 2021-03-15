namespace DemoAcmeAp.Domain.Services
{
    using DemoAcmeAp.Domain.Entities;
    using DemoAcmeAp.Domain.Interfaces.Services;
    using DemoAcmeAp.Domain.Interfaces.UoW;
    using System.Threading.Tasks;

    internal class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IUnitOfWork uow;

        public ClienteService(IUnitOfWork uow) : base(uow.Clientes)
        {
            this.uow = uow;
        }

        public async Task<Cliente> FindByCpf(string cpf)
        {
            return await uow.Clientes.FindByCpf(cpf);
        }
    }
}