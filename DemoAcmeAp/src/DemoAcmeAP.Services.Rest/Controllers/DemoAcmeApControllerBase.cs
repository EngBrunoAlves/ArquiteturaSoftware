namespace DemoAcmeAP.Services.Rest.Controllers
{
    using DemoAcmeAp.Application.Interfaces.Base;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public abstract class DemoAcmeApControllerBase<TViewModel> : ControllerBase where TViewModel : class
    {
        private readonly IAppServiceBase<TViewModel> appService;

        protected DemoAcmeApControllerBase(IAppServiceBase<TViewModel> appService)
        {
            this.appService = appService;
        }

        [HttpPost]
        public async Task<TViewModel> Add([FromBody] TViewModel viewModel)
        {
            return await appService.Add(viewModel);
        }

        [HttpPut("{id}")]
        public async Task<TViewModel> Update(long id, [FromBody] TViewModel viewModel)
        {
            return await appService.Update(id, viewModel);
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await appService.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<TViewModel> Get(long id)
        {
            return await appService.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<TViewModel>> List()
        {
            return await appService.List();
        }
    }
}