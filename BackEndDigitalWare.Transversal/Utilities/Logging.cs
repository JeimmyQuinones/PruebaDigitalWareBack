using BackEndDigitalWare.Transversal.Models;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace BackEndDigitalWare.Transversal.Utilities
{
    public class Logging: ILogging
    {
        private readonly ILogger<Logging> _logger;
        public Logging (ILogger<Logging> logger)
        {
            _logger = logger;
        }
        /// <summary>
        ///  Fuincion encargada de insertar un registro de auditoria para un error en especifico
        /// </summary>
        /// <param name="exception">Detalle de la excepcion ocurrida</param>
        /// <param name="SentParameters">Parametro de entrada el metodo auditoria</param>
        /// <param name="BusinessMessage">Mensaje personalizado del error ocurrido</param>
        /// <param name="UserData">Información general del usuario</param>
        /// <param name="nombreClass">Nombre de la clase</param>
        /// <param name="nombreMethod">Nombre del método</param>
        public void LogError(
            Exception exception,
            object SentParameters,
            string BusinessMessage,
            object UserData,
            [CallerFilePath] string nombreClass =null,
            [CallerMemberName] string nombreMethod=null
            )
        {
            Audit audit = new Audit();
            audit.Class = Path.GetFileName(nombreClass);
            audit.Method = nombreMethod;
            audit.SentParameters = SentParameters;
            audit.UserData = UserData;
            audit.BusinessMessage = BusinessMessage;
            audit.ErrorMessage = exception.Message;
            audit.ExceptionMessage = exception.StackTrace;
            _logger.LogError("{@Audit}",audit);
        }
        /// <summary>
        ///  Fuincion encargada de insertar un registro de auditoria 
        /// </summary>
        /// <param name="SentParameters">Parametros de entrada del metodo</param>
        /// <param name="ResultParameters">Parametros de salida del metodo</param>
        /// <param name="BusinessMessage">Mensaje personalizado del proceso auditado</param>
        /// <param name="UserData">Información general del usuario</param>
        /// <param name="nombreClass">Nombre de la clase</param>
        /// <param name="nombreMethod">Nombre del método</param>
        public void LogInformation(
           object SentParameters,
           object ResultParameters,
           string BusinessMessage,
           object UserData,
           [CallerFilePath] string nombreClass = null,
           [CallerMemberName] string nombreMethod = null
           )
        {
            Audit audit = new Audit();
            audit.Class = Path.GetFileName(nombreClass);
            audit.Method = nombreMethod;
            audit.SentParameters = SentParameters;
            audit.UserData = UserData;
            audit.BusinessMessage = BusinessMessage;
            audit.ResultParameters = ResultParameters;
            _logger.LogWarning("{@Audit}", audit);
        }
        /// <summary>
        /// Fuincion encargada de realizar el registro de auditoria para los servicios expuestos a nivel de controlador
        /// </summary>
        /// <param name="audit"> Objeto Auditoria </param>
        public void LogFilter(Audit audit)
        {
            _logger.LogWarning("{@Audit}", audit);
        }

    }
}
