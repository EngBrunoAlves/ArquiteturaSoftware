namespace DemoAcmeAp.Domain.Services
{
    using DemoAcmeAp.Domain.Entities;
    using DemoAcmeAp.Domain.Interfaces.Services;
    using DemoAcmeAp.Domain.Interfaces.UoW;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class FaturaService : ServiceBase<Fatura>, IFaturaService
    {
        private readonly IUnitOfWork uow;

        public FaturaService(IUnitOfWork uow) : base(uow.Faturas)
        {
            this.uow = uow;
        }

        public async Task<Fatura> FindByCodigo(string codigo)
        {
            return await uow.Faturas.FindByCodigo(codigo);
        }

        public async Task<IEnumerable<Fatura>> FindByClienteCpf(string clienteCpf)
        {
            return await uow.Faturas.FindByClienteCpf(clienteCpf);
        }
    }
}