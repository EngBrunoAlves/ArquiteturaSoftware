namespace BillsToPay.Repository.MySql.IoC
{
    using BillsToPay.Domain.Interfaces.UoW;
    using BillsToPay.Repository.MySql.UoW;
    using Microsoft.Extensions.DependencyInjection;

    public static class IoC
    {
        public static void RepositoryIoC(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}