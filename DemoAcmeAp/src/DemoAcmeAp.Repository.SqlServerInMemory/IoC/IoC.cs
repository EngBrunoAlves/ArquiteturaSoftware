namespace DemoAcmeAp.Repository.SqlServerInMemory.IoC
{
    using DemoAcmeAp.Domain.Interfaces.UoW;
    using DemoAcmeAp.Repository.SqlServerInMemory.Context;
    using DemoAcmeAp.Repository.SqlServerInMemory.UoW;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class IoC
    {
        public static void RepositoryIoC(this IServiceCollection services)
        {
            services.AddDbContext<DemoAcmeApContext>(opt => opt.UseInMemoryDatabase("DemoAcmeApDb"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}