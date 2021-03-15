namespace DemoAcmeAp.Domain.Interfaces.Repositories
{
    using System.Threading.Tasks;
    using DemoAcmeAp.Domain.Entities;

    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Task<Cliente> FindByCpf(string cpf);
    }
}