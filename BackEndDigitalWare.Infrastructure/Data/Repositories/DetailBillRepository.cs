using BackEndDigitalWare.Aplication;
using BackEndDigitalWare.Domain.Contracts;
using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Infrastructure.Data.Repositories
{
    public class DetailBillRepository: IDetailBillRepository
    {
        private readonly IDBContext _DBContext;
        public DetailBillRepository(IDBContext DBContext)
        {
            _DBContext = DBContext;
        }

        /// <summary>
        /// Metodo encargado de buscar los detalle de una factura en la base de datos
        /// </summary>
        /// <param name="billId">Id de la factura</param>
        /// <returns>Objeto Factura</returns>
        public async Task<List<DetailBill>> DetailBillByBillIdFindAsync(Guid billId)
        {
            try
            {
                return await _DBContext.DetailBill
                    .AsNoTracking().Where(
                    x => x.BillId.Equals(billId)
                    ).ToListAsync();
            }
            catch
            {
                throw new BackEndDigitalWareException($"Ocurrió un error al consultar la factura" + $"{billId}.");
            }
        }
        /// <summary>
        /// Metodo encargado de guardar una lista de detalles en la base de datos
        /// </summary>
        /// <param name="ListDetail">Lista de Detalles Factura/param>
        /// <returns></returns>
        public async Task DetailBillListAddAsync(List<DetailBill> ListDetail)
        {
            try
            {
                if (ListDetail.Count > 0)
                {
                    await _DBContext.DetailBill.AddRangeAsync(ListDetail);
                    await _DBContext.SaveChangesAsync();
                }
                
            }
            catch (Exception ex)
            {
                _DBContext.DetailBill.RemoveRange(ListDetail);
                throw new BackEndDigitalWareException($"Ocurrió un error al agregar los detalles de la factura" + ex.InnerException.ToString());
            }
        }

        /// <summary>
        /// Metodo encargado de actualizar una lista de detalles en la base de datos
        /// </summary>
        /// <param name="ListDetail">Lista de Detalles Factura/param>
        /// <returns></returns>
        public async Task DetailBillListUpdateAsync(List<DetailBill> ListDetail)
        {
            try
            {
                if (ListDetail.Count > 0)
                {
                    _DBContext.DetailBill.UpdateRange(ListDetail);
                    await _DBContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _DBContext.DetailBill.RemoveRange(ListDetail);
                throw new BackEndDigitalWareException($"Ocurrió un error al agregar los detalles de la factura" + ex.InnerException.ToString());
            }
        }


        /// <summary>
        /// Metodo encargado de eliminar una lista de detalles en la base de datos
        /// </summary>
        /// <param name="ListDetail">Lista de Detalles Factura/param>
        /// <returns></returns>
        public async Task DetailBillListDeleteAsync(List<DetailBill> ListDetail)
        {
            try
            {
                _DBContext.DetailBill.RemoveRange(ListDetail);
                await _DBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BackEndDigitalWareException($"Ocurrió un error al eliminar la lista de detalles" + ex.InnerException.ToString());
            }
        }
    }
}
