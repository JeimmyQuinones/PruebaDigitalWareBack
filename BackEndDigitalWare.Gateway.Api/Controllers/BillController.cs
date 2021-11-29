using Microsoft.AspNetCore.Mvc;
using BackEndDigitalWare.Gateway.Api.Filters;
using BackEndDigitalWare.Gateway.Api.Services.Contracts;
using System.Threading.Tasks;
using System;
using BackEndDigitalWare.Gateway.Api.ViewModels;

namespace BackEndDigitalWare.Gateway.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(
            IBillService billService)
        {
            _billService = billService;
        }

        /// <summary>
        ///  Metodo encargado de buscar el listado de facturas
        /// </summary>
        /// <returns>Listado de Facturas</returns>
        [HttpGet]
        [Audit(auditInput:true, auditResult:true, description:"Busca el listado de facturas")]
        public async Task<ActionResult> ListBills()
        {
            try
            {
                return Ok(await _billService.FindBillList()); ;
            }
            catch
            {
                return BadRequest();
            }
            
        }
        /// <summary>
        ///  Metodo encargado de buscar el listado de detalles de una factura
        /// </summary>
        /// <returns>Listado de detalles</returns>
        [HttpGet]
        [Audit(auditInput: true, auditResult: true, description: "Busca los detalles de una factura ")]
        public async Task<ActionResult> ListDetailBills(string billId)
        {
            try
            {
                return Ok(await _billService.FindDetailBillList(billId)); ;
            }
            catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        ///  Metodo encargado de Eliminar Facturas
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Audit(auditInput: true, auditResult: true, description: "Elimina la factura")]
        public async Task<ActionResult> DeleteBill(string billId)
        {
            try
            {
                await _billService.DeleteBillAndDetailOfBills(billId);
                return Ok(); 
            }
            catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        ///  Metodo encargado de crear o actualizar las facturas y sus correspondientes detalles
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Audit(auditInput: true, auditResult: true, description: "Crea o actualiza las facturas y sus detalles")]
        public async Task<ActionResult> CreateOrUpdateBill(BillAddViewModel billModel)
        {
            try
            {
                await _billService.CreateOrEditBills(billModel);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo encargado de buscar un cliente por tipo y numero de identificación
        /// </summary>
        /// <param name="identificationType">Tipo de itentificacion</param>
        /// <param name="documentNumber">Numero de identificación</param>
        /// <returns></returns>
        [HttpPost]
        [Audit(auditInput: true, auditResult: true, description: "Busca un cliente por tipo y numero de identificación")]
        public async Task<ActionResult> GetCustomer(int identificationType, string documentNumber)
        {
            try
            {
                return Ok(await _billService.FindCustomer(identificationType, documentNumber));
            }
            catch
            {
                return BadRequest();
            }
        }



    }
}
