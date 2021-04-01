namespace BillsToPay.Services.Rest.Controllers
{
    using BillsToPay.Application.Interfaces;
    using BillsToPay.Application.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class BillToPayController : BillsToPayControllerBase<BillToPayViewModel>
    {
        private readonly IBillToPayAppService _billToPayAppService;

        public BillToPayController(IBillToPayAppService billToPayAppService) : base(billToPayAppService)
        {
            _billToPayAppService = billToPayAppService;
        }

        [HttpGet("ListBillToPayLate")]
        public async Task<IEnumerable<BillToPayLateViewModel>> ListBillToPayLate()
        {
            return await _billToPayAppService.ListBillToPayLate();
        }
    }
}
