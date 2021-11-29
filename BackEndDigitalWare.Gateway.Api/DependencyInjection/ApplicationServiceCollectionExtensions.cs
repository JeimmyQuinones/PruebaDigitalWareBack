using BackEndDigitalWare.Aplication.Commands.AddNewBill;
using BackEndDigitalWare.Aplication.Commands.DeleteBill;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndDigitalWare.Gateway.Api.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        /// <summary>
        /// Función encargada de inyectar los casos de uso
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IDeleteBill, DeleteBill>();
            services.AddTransient<IAddOrEditBill, AddOrEditBill>();

            return services;
        }
    }
}
