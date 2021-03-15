namespace DemoAcmeAp.Domain.Interfaces.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DemoAcmeAp.Domain.Entities;

    public interface IFaturaRepository : IRepositoryBase<Fatura>
    {
        Task<Fatura> FindByCodigo(string codigo);
        Task<IEnumerable<Fatura>> FindByClienteCpf(string clienteCpf);
    }
}