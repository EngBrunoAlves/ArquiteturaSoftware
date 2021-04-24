namespace BillsToPay.Services.Rest.IoC
{
    using System;
    using System.IO;
    using BillsToPay.Repository.MongoDb.IoC;
    using BillsToPay.Repository.MySql.IoC;
    using BillsToPay.Services.Rest.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.PlatformAbstractions;
    using Microsoft.OpenApi.Models;
    using Serilog;
    using Serilog.Sinks.Elasticsearch;

    public static class IoC
    {
        public static void RepositoryIoC(this IServiceCollection services, IConfiguration Configuration)
        {
            var config = Configuration.GetSection("BillsToPayConfig:Database").Value;
            var database = Enum.Parse(typeof(Database), config, true);

            switch (database)
            {
                case Database.MySql:
                    services.MySqlRepositoryIoC(Configuration);
                    return;
                case Database.MongoDb:
                    services.MongoDbRepositoryIoC(Configuration);
                    return;
                default:
                    return;
            }
        }

        public static void LoggerIoC(this IServiceCollection services, IConfiguration Configuration)
        {
            var uri = Configuration.GetSection("ElasticConfiguration:Uri").Value;
            var username = Configuration.GetSection("ElasticConfiguration:Username").Value;
            var password = Configuration.GetSection("ElasticConfiguration:Password").Value;

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(uri))
                {
                    AutoRegisterTemplate = true,
                    ModifyConnectionSettings = x => x.BasicAuthentication(username, password)
                })
                .CreateLogger();
        }

        public static void SwaggerIoC(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BillsToPay API"
                });

                var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
                var applicationName = PlatformServices.Default.Application.ApplicationName;
                var xmlDocPath = Path.Combine(applicationBasePath, $"{applicationName}.xml");
                c.IncludeXmlComments(xmlDocPath);
            });
        }

        public static void LoggerConfigure(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
        }

        public static void SwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "OpenWeather API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}