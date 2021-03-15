namespace DemoAcmeAp.Application.AppServices
{
    using DemoAcmeAp.Application.Interfaces;
    using DemoAcmeAp.Application.ViewModels;
    using DemoAcmeAp.Domain.Entities;
    using DemoAcmeAp.Domain.Interfaces.Services;
    using DemoAcmeAp.Domain.Interfaces.UoW;
    using global::AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class InstalacaoAppService : AppServiceBase<Instalacao, InstalacaoViewModel>, IInstalacaoAppService
    {
        private readonly IInstalacaoService service;

        public InstalacaoAppService(IInstalacaoService service, IUnitOfWork uow, IMapper mapper) : base(service, uow, mapper)
        {
            this.service = service;
        }

        public async Task<InstalacaoViewModel> FindByCodigo(string codigo)
        {
            var result = await service.FindByCodigo(codigo);

            return mapper.Map<InstalacaoViewModel>(result);
        }

        public async Task<IEnumerable<InstalacaoViewModel>> FindByClienteCpf(string clienteCpf)
        {
            var result = await service.FindByClienteCpf(clienteCpf);

            return result
                .Select(r => mapper.Map<InstalacaoViewModel>(r))
                .ToList();
        }
    }
}