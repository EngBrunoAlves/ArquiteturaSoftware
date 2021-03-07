namespace BillsToPay.Application.AutoMapper
{
    using BillsToPay.Application.ViewModels;
    using BillsToPay.Domain.Dtos;
    using BillsToPay.Domain.Entities;
    using global::AutoMapper;
    using Microsoft.Extensions.DependencyInjection;

    internal static class AutoMapperConfig
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<BillToPayViewModel, BillToPay>();
                config.CreateMap<BillToPay, BillToPayViewModel>();
                config.CreateMap<BillToPayLateViewModel, BillToPayLateDto>();
                config.CreateMap<BillToPayLateDto, BillToPayLateViewModel>();
            });

            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
