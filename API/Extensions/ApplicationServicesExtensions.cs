using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            //dodanie zakresu generycznego
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // dodanie zakresu
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IBasketRepository, BasketRepository>();
            return services;
        }
    }
}
