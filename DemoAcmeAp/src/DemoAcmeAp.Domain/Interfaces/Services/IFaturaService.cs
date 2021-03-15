namespace DemoAcmeAp.Domain.Interfaces.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DemoAcmeAp.Domain.Entities;

    public interface IFaturaService : IServiceBase<Fatura>
    {
        Task<Fatura> FindByCodigo(string codigo);
        Task<IEnumerable<Fatura>> FindByClienteCpf(string clienteCpf);
    }
}