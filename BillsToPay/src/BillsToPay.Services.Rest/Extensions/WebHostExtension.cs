namespace BillsToPay.Services.Rest
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BillsToPay.Domain.Entities;
    using BillsToPay.Domain.Interfaces.UoW;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class WebHostExtension
    {
        public static IHost SeedData(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var uow = services.GetService<IUnitOfWork>();

            var task = Task.Run(async () =>
            {
                if (await uow.LateFees.Any())
                    return;

                uow.BeginTransaction();

                var data = GetData();

                await uow.LateFees.AddRange(data);

                await uow.Commit();
            });

            task.Wait();

            return host;
        }

        private static IEnumerable<LateFee> GetData()
        {
            return new[] {
                new LateFee{
                    MinDaysInOverdue = 0,
                    Fee = 2,
                    InterestPerDay = 0.1m
                },
                new LateFee{
                    MinDaysInOverdue = 3,
                    Fee = 3,
                    InterestPerDay = 0.2m
                },
                new LateFee{
                    MinDaysInOverdue = 5,
                    Fee = 5,
                    InterestPerDay = 0.3m
                }
            };
        }
    }
}