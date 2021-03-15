namespace DemoAcmeAp.Application.AutoMapper
{
    using DemoAcmeAp.Application.ViewModels;
    using DemoAcmeAp.Domain.Entities;
    using global::AutoMapper;
    using Microsoft.Extensions.DependencyInjection;

    internal static class AutoMapperConfig
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Cliente, ClienteViewModel>().ReverseMap();
                config.CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
                config.CreateMap<Fatura, FaturaViewModel>().ReverseMap();
                config.CreateMap<Instalacao, InstalacaoViewModel>().ReverseMap();
            });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
