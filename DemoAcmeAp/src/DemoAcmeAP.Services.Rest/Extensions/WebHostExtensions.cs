namespace DemoAcmeAP.Services.Rest
{
    using DemoAcmeAp.Repository.SqlServerInMemory.Context;
    using DemoAcmeAp.Repository.SqlServerInMemory.Seed;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class WebHostExtensions
    {
        public static IHost SeedData(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetService<DemoAcmeApContext>();

            context.SeedData();

            return host;
        }
        
    }
}