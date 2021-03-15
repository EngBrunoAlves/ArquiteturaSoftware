namespace DemoAcmeAp.Application.Interfaces
{
    using DemoAcmeAp.Application.Interfaces.Base;
    using DemoAcmeAp.Application.ViewModels;
    using DemoAcmeAp.Domain.Entities;
    using System.Threading.Tasks;

    public interface IClienteAppService : IAppServiceBase<ClienteViewModel>
    {
        Task<ClienteViewModel> FindByCpf(string cpf);
    }
}