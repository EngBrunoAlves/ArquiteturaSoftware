namespace DemoAcmeAp.Domain.Services
{
    using DemoAcmeAp.Domain.Entities;
    using DemoAcmeAp.Domain.Interfaces.Services;
    using DemoAcmeAp.Domain.Interfaces.UoW;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class InstalacaoService : ServiceBase<Instalacao>, IInstalacaoService
    {
        private readonly IUnitOfWork uow;

        public InstalacaoService(IUnitOfWork uow) : base(uow.Instalacoes)
        {
            this.uow = uow;
        }

        public async Task<Instalacao> FindByCodigo(string codigo)
        {
            return await uow.Instalacoes.FindByCodigo(codigo);
        }

        public async Task<IEnumerable<Instalacao>> FindByClienteCpf(string clienteCpf)
        {
            return await uow.Instalacoes.FindByClienteCpf(clienteCpf);
        }
    }
}