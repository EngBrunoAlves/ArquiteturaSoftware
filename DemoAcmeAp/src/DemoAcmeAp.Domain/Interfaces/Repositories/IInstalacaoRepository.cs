namespace DemoAcmeAp.Domain.Interfaces.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DemoAcmeAp.Domain.Entities;

    public interface IInstalacaoRepository : IRepositoryBase<Instalacao>
    {
        Task<Instalacao> FindByCodigo(string codigo);
        Task<IEnumerable<Instalacao>> FindByClienteCpf(string clientCpf);
    }
}