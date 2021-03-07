namespace BillsToPay.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BillsToPay.Application.ViewModels;

    public interface IBillToPayAppService
    {
        Task Create(BillToPayViewModel billToPayViewModel);
        Task<IEnumerable<BillToPayLateViewModel>> List();
    }
}