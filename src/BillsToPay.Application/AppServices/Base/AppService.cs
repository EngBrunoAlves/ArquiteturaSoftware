namespace BillsToPay.Application.AppServices.Base
{
    using BillsToPay.Domain.Interfaces.UoW;
    using global::AutoMapper;

    internal abstract class AppService
    {
        private readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        protected AppService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.Commit();
        }

        public void RollBack()
        {
            _uow.Rollback();
        }
    }
}