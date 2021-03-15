namespace DemoAcmeAp.Application.AppServices
{
    using DemoAcmeAp.Application.Interfaces.Base;
    using DemoAcmeAp.Domain.Entities;
    using DemoAcmeAp.Domain.Interfaces.Services;
    using DemoAcmeAp.Domain.Interfaces.UoW;
    using global::AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal abstract class AppServiceBase<TModel, TViewModel> : IAppServiceBase<TViewModel> where TModel : EntityBase where TViewModel : class
    {
        private readonly IServiceBase<TModel> service;
        protected readonly IUnitOfWork uow;
        protected readonly IMapper mapper;

        protected AppServiceBase(IServiceBase<TModel> service, IUnitOfWork uow, IMapper mapper)
        {
            this.service = service;
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<TViewModel> Add(TViewModel viewModel)
        {
            var entity = mapper.Map<TModel>(viewModel);

            BeginTransaction();
            var result = await service.Add(entity);
            Commit();

            return mapper.Map<TViewModel>(result);
        }

        public async Task<TViewModel> Update(long id, TViewModel viewModel)
        {
            var entity = mapper.Map<TModel>(viewModel);

            BeginTransaction();
            var result = await service.Update(id, entity);
            Commit();

            return mapper.Map<TViewModel>(result);
        }

        public async Task Delete(long id)
        {
            BeginTransaction();
            await service.Delete(id);
            Commit();
        }

        public async Task<TViewModel> Get(long id)
        {
            var result = await service.Get(id);

            return mapper.Map<TViewModel>(result);
        }

        public async Task<IEnumerable<TViewModel>> List()
        {
            var result = await service.List();

            return result
                .Select(r => mapper.Map<TViewModel>(r))
                .ToList();
        }

        protected void BeginTransaction()
        {
            //uow.BeginTransaction();
        }

        protected void Commit()
        {
            uow.Commit();
        }

        protected void RollBack()
        {
            uow.Rollback();
        }
    }
}