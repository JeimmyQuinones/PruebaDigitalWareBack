using Microsoft.Extensions.DependencyInjection;
using BackEndDigitalWare.Gateway.Api.Services;
using BackEndDigitalWare.Gateway.Api.Services.Contracts;

namespace BackEndDigitalWare.Gateway.Api.DependencyInjection
{
    /// <summary>
    /// Función encargada de inyectar los servicios de la aplicación
    /// </summary>
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IBillService, BillService>();

            return services;
        }


    }
}
