namespace DemoAcmeAp.Application.IoC
{
    using DemoAcmeAp.Application.AppServices;
    using DemoAcmeAp.Application.AutoMapper;
    using DemoAcmeAp.Application.Interfaces;
    using Microsoft.Extensions.DependencyInjection;

    public static class IoC
    {
        public static void ApplicationIoC(this IServiceCollection services)
        {
            services.RegisterMappings();
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IFaturaAppService, FaturaAppService>();
            services.AddScoped<IInstalacaoAppService, InstalacaoAppService>();
        }
    }
}