using BackEndDigitalWare.Transversal.Models;
using BackEndDigitalWare.Transversal.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using log = BackEndDigitalWare.Transversal;

namespace BackEndDigitalWare.Gateway.Api.Filters
{
    public class AuditAttribute : Microsoft.AspNetCore.Mvc.TypeFilterAttribute
    {
        /// <summary>
        /// Constructor de la clase AuditAttribute
        /// </summary>
        /// <param name="auditInput"> Indica si se debe o no auditar los parametros de entrada del metodo de acción</param>
        /// <param name="auditResult"> Indica si se deben o no auditar los parametros de respuesta del método de acción</param>
        /// <param name="description">Descripción de la acción auditoria</param>
        public AuditAttribute(bool auditInput = false, bool auditResult = false, string description = "")
            : base(typeof(Audit))
        {
            Arguments = new object[] { auditInput, auditResult, description };
        }
    }
    public class Audit : IActionFilter
    {
        private readonly string _description;
        private readonly bool _auditInput;
        private readonly bool _auditResult;
        private readonly log.Models.Audit _audit;
        private readonly ILogging _logging;
        /// <summary>
        /// Constructor clase auditoria 
        /// </summary>
        /// <param name="auditInput"> Indica si se debe o no auditar los parametros de entrada del metodo de acción</param>
        /// <param name="auditResult"> Indica si se deben o no auditar los parametros de respuesta del método de acción</param>
        /// <param name="description">Descripción de la acción auditoria</param>
        /// <param name="logging">Acceso a registro auditoria</param>
        public Audit(
            string description,
            bool auditInput,
            bool auditResult,
            ILogging logging)
        {
            _description = description;
            _auditInput = auditInput;
            _auditResult = auditResult;
            _logging = logging;
            _audit = new log.Models.Audit();
        }
        /// <summary>
        /// Operación encargada de capturar los datos iniciales del método de acción
        /// </summary>
        /// <param name="context">contexto de acción ejecutada</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _audit.Class = context.Controller.ToString();
            _audit.Method = context.ActionDescriptor.DisplayName;
            _audit.DescripctionMethod = _description;
            _audit.SentParameters = null;
            var inputParameters = context.ActionArguments.Values;
            if (_auditInput &&
                inputParameters != null &&
                inputParameters.Count > 0)
            {
                _audit.SentParameters = JsonConvert.SerializeObject(inputParameters);
            }
        }
        /// <summary>
        /// Operación encargada de capturar el resultado del método de acción 
        /// </summary>
        /// <param name="context">Contexto de acción ejecutada</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (_auditResult &&
                context.Result != null &&
                context.Result is ObjectResult)
            {
                var ResultParameters = (ObjectResult)context.Result;
                _audit.ResultParameters = ResultParameters.Value;
            }
            ValidateException(context);
            _logging.LogFilter(_audit);
        }
        /// <summary>
        /// Operación encargada de guardar la infromación de la excepcion 
        /// </summary>
        /// <param name="context"> Contexto de acción ejecutada</param>
        private void ValidateException(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                Result result = new Result();
                result.Error = true;
                result.Message = "Ocurrio un error interno en el api";
                _audit.ErrorMessage = context.Exception.Message;
                _audit.ExceptionMessage = context.Exception.StackTrace;
            }
        }



    }
}
