namespace OpenWeather.Application.AppServices.Base
{
    using OpenWeather.Domain.Interfaces.UoW;

    internal abstract class AppServiceBase
    {
        private readonly IUnitOfWork uow;

        protected AppServiceBase(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        
        protected void BeginTransaction()
        {
            uow.BeginTransaction();
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