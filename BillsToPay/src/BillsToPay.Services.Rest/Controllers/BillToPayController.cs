namespace BillsToPay.Services.Rest.Controllers
{
    using BillsToPay.Application.Interfaces;
    using BillsToPay.Application.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class BillToPayController : ControllerBase
    {
        private readonly IBillToPayAppService _appService;

        public BillToPayController(IBillToPayAppService appService)
        {
            _appService = appService;
        }

        [HttpPost]
        public async Task Create(BillToPayViewModel billToPay)
        {
            await _appService.Create(billToPay);
        }

        [HttpGet]
        public async Task<IEnumerable<BillToPayLateViewModel>> List()
        {
            return await _appService.List();
        }
    }
}
