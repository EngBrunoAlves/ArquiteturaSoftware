namespace BillsToPay.Services.Rest.Controllers
{
    using BillsToPay.Application.Interfaces;
    using BillsToPay.Application.ViewModels;
    using BillsToPay.Services.Rest.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class BillToPayController : BillsToPayControllerBase<BillToPayViewModel>
    {
        private readonly IBillToPayAppService _billToPayAppService;
        public BillToPayController(IBillToPayAppService billToPayAppService, ILogger<BillToPayController> logger)
            : base(billToPayAppService, logger)
        {
            _billToPayAppService = billToPayAppService;
        }

        [HttpGet("ListBillToPayLate")]
        public async Task<TResult<IEnumerable<BillToPayLateViewModel>>> ListBillToPayLate()
        {
            return await Execute(() => _billToPayAppService.ListBillToPayLate());
        }
    }
}
