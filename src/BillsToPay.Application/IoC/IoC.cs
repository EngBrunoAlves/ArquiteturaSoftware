namespace BillsToPay.Application.IoC
{
    using BillsToPay.Application.AppServices;
    using BillsToPay.Application.AutoMapper;
    using BillsToPay.Application.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class IoC
    {
        public static void ApplicationIoC(this IServiceCollection services)
        {
            services.RegisterMappings();
            services.AddScoped<IBillToPayAppService, BillToPayAppService>();
        }
    }
}