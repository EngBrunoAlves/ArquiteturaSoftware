namespace BillsToPay.Application.IoC
{
    using BillsToPay.Application.AutoMapper;
    using BillsToPay.Application.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class IoC
    {
        public static void ApplicationIoC(this IServiceCollection services)
        {
            services.RegisterMappings();
            services.AddAppServices();
            services.AddWrappers();
        }

        private static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IBillToPayAppService, AppServices.BillToPayAppService>();
        }

        private static void AddWrappers(this IServiceCollection services)
        {
            services.AddScoped<IBillToPayAppService, AppServices.Wrappers.BillToPayAppService>();
        }
    }
}