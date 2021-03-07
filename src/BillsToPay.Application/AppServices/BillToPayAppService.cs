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

    internal class BillToPayAppService : AppService, IBillToPayAppService
    {
        private readonly IBillToPayService _billToPayService;

        public BillToPayAppService(IBillToPayService billToPayService, IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
            _billToPayService = billToPayService;
        }

        public async Task Create(BillToPayViewModel billToPayViewModel)
        {
            var billToPay = _mapper.Map<BillToPay>(billToPayViewModel);

            BeginTransaction();
            await _billToPayService.Create(billToPay);
            Commit();
        }

        public async Task<IEnumerable<BillToPayLateViewModel>> List()
        {
            var billsToPay = await _billToPayService.List();

            return billsToPay
                .Select(b => _mapper.Map<BillToPayLateViewModel>(b))
                .ToList();
        }
    }
}