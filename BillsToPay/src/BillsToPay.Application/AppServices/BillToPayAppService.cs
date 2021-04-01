namespace BillsToPay.Application.AppServices
{
	using BillsToPay.Application.AppServices.Base;
	using BillsToPay.Application.Interfaces;
	using BillsToPay.Application.ViewModels;
	using BillsToPay.Domain.Entities;
	using BillsToPay.Domain.Interfaces.Services;
	using BillsToPay.Domain.Interfaces.UoW;
	using global::AutoMapper;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	internal sealed class BillToPayAppService : AppServiceBase<BillToPay, BillToPayViewModel>, IBillToPayAppService
	{
		private readonly IBillToPayService _billToPayService;

		public BillToPayAppService(IBillToPayService billToPayService, IUnitOfWork uow, IMapper mapper) : base(billToPayService, uow, mapper)
		{
			_billToPayService = billToPayService;
		}

		public async Task<IEnumerable<BillToPayLateViewModel>> ListBillToPayLate()
		{
			var billsToPay = await _billToPayService.ListBillToPayLateDto();

			return billsToPay
				.Select(b => _mapper.Map<BillToPayLateViewModel>(b))
				.ToList();
		}

		protected override void DisposeCustom()
		{
			//nop
		}
	}
}