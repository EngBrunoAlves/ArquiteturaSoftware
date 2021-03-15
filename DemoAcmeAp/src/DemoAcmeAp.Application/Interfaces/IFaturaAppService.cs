namespace DemoAcmeAp.Application.Interfaces
{
    using DemoAcmeAp.Application.Interfaces.Base;
    using DemoAcmeAp.Application.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFaturaAppService : IAppServiceBase<FaturaViewModel>
    {
        Task<FaturaViewModel> FindByCodigo(string codigo);
        Task<IEnumerable<FaturaViewModel>> FindByClienteCpf(string clienteCpf);
    }
}