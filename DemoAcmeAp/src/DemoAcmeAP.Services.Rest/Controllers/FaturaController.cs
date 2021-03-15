namespace DemoAcmeAP.Services.Rest.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DemoAcmeAp.Application.Interfaces;
    using DemoAcmeAp.Application.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class FaturaController : DemoAcmeApControllerBase<FaturaViewModel>
    {
        private readonly IFaturaAppService appService;

        public FaturaController(IFaturaAppService appService) : base(appService)
        {
            this.appService = appService;
        }

        [HttpGet("codigo/{codigo}")]
        public async Task<FaturaViewModel> GetByCodigo(string codigo)
        {
            return await appService.FindByCodigo(codigo);
        }

        [HttpGet("cliente/cpf/{clienteCpf}")]
        public async Task<IEnumerable<FaturaViewModel>> GetByClienteCpf(string clienteCpf)
        {
            return await appService.FindByClienteCpf(clienteCpf);
        }
    }
}
