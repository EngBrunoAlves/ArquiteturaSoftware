namespace DemoAcmeAP.Services.Rest.Controllers
{
    using DemoAcmeAp.Application.Interfaces;
    using DemoAcmeAp.Application.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : DemoAcmeApControllerBase<ClienteViewModel>
    {
        private readonly IClienteAppService appService;

        public ClienteController(IClienteAppService appService) : base(appService)
        {
            this.appService = appService;
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ClienteViewModel> FindByCpf(string cpf)
        {
            return await appService.FindByCpf(cpf);
        }
    }
}
