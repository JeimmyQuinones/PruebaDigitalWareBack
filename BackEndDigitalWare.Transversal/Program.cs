using Microsoft.Extensions.Configuration;
using Serilog;

namespace BackEndDigitalWare.Transversal
{
    public class Program
    {
        /// <summary>
        /// Método encargado de realizar la configuración general del proveedor del logging
        /// </summary>
        /// <param name="configuration"> Información general del archivo de configuración </param>
        /// <param name="Name"></param>
        /// <returns>Objeto para el registro de logs</returns>
        public static ILogger CreateSerilogLogger(IConfiguration configuration, string Name)
        {
            return new LoggerConfiguration()
                .Enrich.WithProperty("AplicationContext", Name)
                .Enrich.WithProperty("Audit", null)
                .Enrich.FromLogContext()
                .WriteTo.File("Logs/log.txt",rollingInterval:RollingInterval.Day)
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}
