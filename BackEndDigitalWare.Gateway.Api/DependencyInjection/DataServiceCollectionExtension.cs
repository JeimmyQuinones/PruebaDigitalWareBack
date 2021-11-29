using BackEndDigitalWare.Aplication.Queries;
using BackEndDigitalWare.Domain.Contracts;
using BackEndDigitalWare.Infrastructure.Data;
using BackEndDigitalWare.Infrastructure.Data.Queries;
using BackEndDigitalWare.Infrastructure.Data.Repositories;
using BackEndDigitalWare.Transversal.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndDigitalWare.Gateway.Api.DependencyInjection
{
    public static class DataServiceCollectionExtension
    {
        /// <summary>
        /// Función encargada de inyectar los repositorios y configuración de la base de datos
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IQueriesRepository, QueriesRepository>();
            services.AddTransient<IBillRepository, BillRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IDetailBillRepository, DetailBillRepository>();
            services.AddTransient<IIdentificationTypeRepository, IdentificationTypeRepository>();
            services.AddTransient<IMarkRepository, MarkRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ILogging, Logging>();
            services.AddScoped<IDBContext, DBContext>();
            services.AddDbContext<DBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DataBase")));
            return services;

        }
    }
}
