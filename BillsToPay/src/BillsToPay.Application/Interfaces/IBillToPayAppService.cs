namespace BillsToPay.Application.Interfaces
{
	using BillsToPay.Application.ViewModels;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IBillToPayAppService : IAppServiceBase<BillToPayViewModel>
	{
		Task<IEnumerable<BillToPayLateViewModel>> ListBillToPayLate();
	}
}