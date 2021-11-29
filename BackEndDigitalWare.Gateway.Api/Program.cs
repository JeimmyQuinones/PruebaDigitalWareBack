using BackEndDigitalWare.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using config = BackEndDigitalWare.Transversal.Program;

namespace BackEndDigitalWare.Gateway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDBIfNoExist(host);
            host.Run();

        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((context, configBuilder) =>
            {
                var Configuration = configBuilder.Build();
                Log.Logger = config.CreateSerilogLogger(Configuration, "BackEndDigitalWare.Gateway");
            })
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .UseSerilog();
        /// <summary>
        /// Inicializa las tablas con datos si estan vacias
        /// </summary>
        /// <param name="host"></param>
        private static void CreateDBIfNoExist(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<DBContext>();
            DBInitializer.Initializer(context);
        }
    }
}
