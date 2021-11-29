using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BackEndDigitalWare.Gateway.Api.DependencyInjection
{
    public static class SwaggerCollectionExtensions
    {
        /// <summary>
        /// Metdoto encargado de la configuracion de swagger
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackEnd DigitalWare", Version = "v1" });
            });
            return services;
        }
    }
}
