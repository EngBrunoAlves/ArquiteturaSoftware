namespace BillsToPay.Domain.IoC
{
    using BillsToPay.Domain.Interfaces.Services;
    using BillsToPay.Domain.Services.BillToPay;
    using Microsoft.Extensions.DependencyInjection;

    public static class IoC
    {
        public static void DomainIoC(this IServiceCollection services)
        {
            services.AddScoped<IBillToPayService, BillToPayService>();
        }
    }
}