namespace DemoAcmeAp.Application.Interfaces.Base
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAppServiceBase<TViewModel> where TViewModel : class
    {
        Task<TViewModel> Add(TViewModel viewModel);
        Task<TViewModel> Update(long id, TViewModel viewModel);
        Task Delete(long id);
        Task<TViewModel> Get(long id);
        Task<IEnumerable<TViewModel>> List();
    }
}