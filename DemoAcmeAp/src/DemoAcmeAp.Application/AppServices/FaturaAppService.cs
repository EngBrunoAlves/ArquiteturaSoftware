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

    internal class FaturaAppService : AppServiceBase<Fatura, FaturaViewModel>, IFaturaAppService
    {
        private readonly IFaturaService service;

        public FaturaAppService(IFaturaService service, IUnitOfWork uow, IMapper mapper) : base(service, uow, mapper)
        {
            this.service = service;
        }

        public async Task<FaturaViewModel> FindByCodigo(string codigo)
        {
            var result = await service.FindByCodigo(codigo);

            return mapper.Map<FaturaViewModel>(result);
        }

        public async Task<IEnumerable<FaturaViewModel>> FindByClienteCpf(string clienteCpf)
        {
            var result = await service.FindByClienteCpf(clienteCpf);

            return result
                .Select(r => mapper.Map<FaturaViewModel>(r))
                .ToList();
        }
    }
}