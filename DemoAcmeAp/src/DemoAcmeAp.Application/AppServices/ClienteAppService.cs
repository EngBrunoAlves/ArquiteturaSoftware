namespace DemoAcmeAp.Application.AppServices
{
    using DemoAcmeAp.Application.Interfaces;
    using DemoAcmeAp.Application.ViewModels;
    using DemoAcmeAp.Domain.Entities;
    using DemoAcmeAp.Domain.Interfaces.Services;
    using DemoAcmeAp.Domain.Interfaces.UoW;
    using global::AutoMapper;
    using System.Threading.Tasks;

    internal class ClienteAppService : AppServiceBase<Cliente, ClienteViewModel>, IClienteAppService
    {
        private readonly IClienteService service;

        public ClienteAppService(IClienteService service, IUnitOfWork uow, IMapper mapper) : base(service, uow, mapper)
        {
            this.service = service;
        }

        public async Task<ClienteViewModel> FindByCpf(string cpf)
        {
            var result = await service.FindByCpf(cpf);

            return mapper.Map<ClienteViewModel>(result);
        }
    }
}