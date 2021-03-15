using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoAcmeAP.Services.Rest
{
    using DemoAcmeAp.Application.IoC;
    using DemoAcmeAp.Domain.IoC;
    using DemoAcmeAp.Repository.SqlServerInMemory.IoC;
    using Newtonsoft.Json;

    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Cors
            services.AddCors(options => options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }
            ));

            //IoC
            services.DomainIoC();
            services.RepositoryIoC();
            services.ApplicationIoC();
            services.AddControllers()
                .AddNewtonsoftJson(n =>
                {
                    n.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //n.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            //Cors
            app.UseCors(MyAllowSpecificOrigins);

            //Authentication
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
