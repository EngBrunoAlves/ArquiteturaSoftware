namespace BillsToPay.Application.AppServices.Wrappers
{
    using BillsToPay.Application.Interfaces;
    using BillsToPay.Application.ViewModels;
    using BillsToPay.Domain.Entities;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal sealed class BillToPayAppService
        : AppServiceWrapperBase<IBillToPayAppService, AppServices.BillToPayAppService, BillToPay, BillToPayViewModel>, IBillToPayAppService
    {
        public BillToPayAppService(IServiceProvider provider, ILogger<BillToPayAppService> logger) : base(provider, logger) { }

        public async Task<IEnumerable<BillToPayLateViewModel>> ListBillToPayLate()
        {
            return await Caller(() => appService.ListBillToPayLate());
        }
    }
}