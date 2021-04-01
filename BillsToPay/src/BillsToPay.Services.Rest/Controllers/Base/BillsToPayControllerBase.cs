using BillsToPay.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillsToPay.Services.Rest.Controllers
{
	public abstract class BillsToPayControllerBase<TViewModel> : ControllerBase where TViewModel : class
	{
		private readonly IAppServiceBase<TViewModel> _appService;

		protected BillsToPayControllerBase(IAppServiceBase<TViewModel> appService)
		{
			_appService = appService;
		}

		[HttpPost]
		public async Task<TViewModel> Add([FromBody] TViewModel viewModel)
		{
			return await _appService.Add(viewModel);
		}

        [HttpPut("{id}")]
        public async Task<TViewModel> Update(Guid id, [FromBody] TViewModel viewModel)
        {
            return await _appService.Update(id, viewModel);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _appService.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<TViewModel> Get(Guid id)
        {
            return await _appService.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<TViewModel>> List()
        {
            return await _appService.List();
        }
    }
}
