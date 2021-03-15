namespace DemoAcmeAp.Domain.Interfaces.Services
{
    using DemoAcmeAp.Domain.Entities;
    using System.Threading.Tasks;

    public interface IClienteService : IServiceBase<Cliente>
    {
        Task<Cliente> FindByCpf(string cpf);
    }
}