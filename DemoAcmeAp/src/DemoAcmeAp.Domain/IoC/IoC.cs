namespace DemoAcmeAp.Domain.IoC
{
    using DemoAcmeAp.Domain.Interfaces.Services;
    using DemoAcmeAp.Domain.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class IoC
    {
        public static void DomainIoC(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFaturaService, FaturaService>();
            services.AddScoped<IInstalacaoService, InstalacaoService>();
        }
    }
}