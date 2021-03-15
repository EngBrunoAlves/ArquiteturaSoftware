namespace DemoAcmeAp.Application.Interfaces
{
    using DemoAcmeAp.Application.Interfaces.Base;
    using DemoAcmeAp.Application.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IInstalacaoAppService : IAppServiceBase<InstalacaoViewModel>
    {
        Task<InstalacaoViewModel> FindByCodigo(string codigo);
        Task<IEnumerable<InstalacaoViewModel>> FindByClienteCpf(string clienteCpf);
    }
}