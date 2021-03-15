namespace DemoAcmeAP.Services.Rest.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DemoAcmeAp.Application.Interfaces;
    using DemoAcmeAp.Application.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class InstalacaoController : DemoAcmeApControllerBase<InstalacaoViewModel>
    {
        private readonly IInstalacaoAppService appService;

        public InstalacaoController(IInstalacaoAppService appService) : base(appService)
        {
            this.appService = appService;
        }

        [HttpGet("codigo/{codigo}")]
        public async Task<InstalacaoViewModel> FindByCodigo(string codigo)
        {
            return await appService.FindByCodigo(codigo);
        }

        [HttpGet("cliente/cpf/{clienteCpf}")]
        public async Task<IEnumerable<InstalacaoViewModel>> FindByClienteCpf(string clienteCpf)
        {
            return await appService.FindByClienteCpf(clienteCpf);
        }
    }
}
