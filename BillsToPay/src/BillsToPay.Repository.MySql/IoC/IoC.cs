namespace BillsToPay.Repository.MySql.IoC
{
	using BillsToPay.Domain.Interfaces.UoW;
	using BillsToPay.Repository.MySql.Context;
	using BillsToPay.Repository.MySql.UoW;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using System;

	public static class IoC
    {
        public static void RepositoryIoC(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<BillsToPayContext>(opt => opt.UseMySql(Configuration.GetConnectionString("BillsToPayConnection") ?? throw new ArgumentNullException("BillsToPayConnection")));

			services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}