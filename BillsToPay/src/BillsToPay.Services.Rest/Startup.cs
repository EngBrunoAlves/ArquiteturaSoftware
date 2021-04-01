namespace BillsToPay.Services.Rest
{
    using BillsToPay.Application.IoC;
    using BillsToPay.Domain.IoC;
    using BillsToPay.Repository.MongoDb.IoC;
    using BillsToPay.Repository.MySql.IoC;
    using BillsToPay.Services.Rest.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private const string defaultApiBasePath = "/billstopay";
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

            //Config
            services.Configure<BillsToPayConfig>(Configuration.GetSection("BillsToPayConfig"));

            //IoC
            services.DomainIoC();
            services.ApplicationIoC();
            services.AddControllers();

            if(bool.Parse(Configuration["BillsToPayConfig:UseMySql"]))
                services.MySqlRepositoryIoC(Configuration);

            if(bool.Parse(Configuration["BillsToPayConfig:UseMongoDb"]))
                services.MongoDbRepositoryIoC(Configuration);
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

            //Include Base Path
            string basePath = Configuration["ApiBasePath"] ?? defaultApiBasePath;
            app.UsePathBase(basePath);

            //Authentication
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
