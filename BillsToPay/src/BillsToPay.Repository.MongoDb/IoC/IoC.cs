using BillsToPay.Domain.Interfaces.UoW;
using BillsToPay.Repository.MongoDb.Context;
using BillsToPay.Repository.MongoDb.Models;
using BillsToPay.Repository.MongoDb.UoW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BillsToPay.Repository.MongoDb.IoC
{
	public static class IoC
	{
		public static void RepositoryIoC(this IServiceCollection services, IConfiguration Configuration)
		{
			services.Configure<BillsToPayMongoDbConfig>(Configuration.GetSection(nameof(BillsToPayMongoDbConfig)));
			services.AddSingleton<IBillsToPayMongoDbConfig>(x => x.GetRequiredService<IOptions<BillsToPayMongoDbConfig>>().Value);
			services.AddScoped<BillsToPayContext>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
		}
	}
}
