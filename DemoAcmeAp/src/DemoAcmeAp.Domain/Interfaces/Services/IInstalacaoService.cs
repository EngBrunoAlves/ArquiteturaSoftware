namespace DemoAcmeAp.Domain.Interfaces.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DemoAcmeAp.Domain.Entities;

    public interface IInstalacaoService : IServiceBase<Instalacao>
    {
        Task<Instalacao> FindByCodigo(string codigo);
        Task<IEnumerable<Instalacao>> FindByClienteCpf(string clientCpf);
    }
}