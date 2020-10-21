using E_CommerceAPI.Data;
using E_CommerceAPI.Data.Repository;
using E_CommerceAPI.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceAPI.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //dodanie zakresu generycznego
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            // dodanie zakresu
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IBasketRepository, BasketRepository>();
            return services;
        }
    }
}
