using BackEndDigitalWare.Aplication;
using BackEndDigitalWare.Domain.Contracts;
using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Infrastructure.Data.Repositories
{
    public class BillRepository: IBillRepository
    {
        private readonly IDBContext _DBContext;
        public BillRepository(IDBContext DBContext)
        {
            _DBContext = DBContext;
        }
        /// <summary>
        /// Metodo encargado de buscar una factura en la base de datos
        /// </summary>
        /// <param name="billId">Id de la factura</param>
        /// <returns>Objeto Factura</returns>
        public async Task<Bill> BillByIdFindAsync(Guid billId)
        {
            try
            {
                return await _DBContext.Bill
                    .AsNoTracking()
                    .FirstOrDefaultAsync(
                    x => x.BillId.Equals(billId)
                    );
            }
            catch
            {
                throw new BackEndDigitalWareException($"Ocurrió un error al consultar la factura"+$"{billId}.");
            }
        }


        /// <summary>
        /// Metodo encargado de buscar todas las facturas en la base de datos
        /// </summary>
        /// <returns>Lista de Facturas</returns>
        public async Task<List<Bill>> BillAllAsync()
        {
            try
            {
                return await _DBContext.Bill.ToListAsync();
            }
            catch
            {
                throw new BackEndDigitalWareException($"Ocurrió un error al consultar las facturas");
            }
        }

        /// <summary>
        /// Metodo encargado de guardar una nueva factura en la base de datos
        /// </summary>
        /// <param name="bill">Objeto Factura</param>
        /// <returns></returns>
        public async Task BillAddAsync(Bill bill)
        {
            try
            {
                await _DBContext.Bill.AddAsync(bill);
                await _DBContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _DBContext.Bill.Remove(bill);
                throw new BackEndDigitalWareException($"Ocurrió un error al agregar la factura" + $"{bill}"+ ex.InnerException.ToString());
            }
        }

        /// <summary>
        /// Metodo encargado de actualizar una nueva factura en la base de datos
        /// </summary>
        /// <param name="bill">Objeto Factura</param>
        /// <returns></returns>
        public async Task BillUpdateAsync(Bill bill)
        {
            try
            {
                _DBContext.Bill.Update(bill);
                await _DBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _DBContext.Bill.Remove(bill);
                throw new BackEndDigitalWareException($"Ocurrió un error al actualizar la factura" + $"{bill}" + ex.InnerException.ToString());
            }
        }


        /// <summary>
        /// Metodo encargado de eliminar una factura en la base de datos
        /// </summary>
        /// <param name="bill">Id Factura</param>
        /// <returns></returns>
        public async Task BillDeleteAsync(Guid billId)
        {
            try
            {
                var bill = await _DBContext.Bill
                    .AsNoTracking()
                    .FirstOrDefaultAsync(
                    x => x.BillId.Equals(billId));
                if(bill== null)
                {
                    throw new BackEndDigitalWareException($"´La factura no exite en la base de datos" + $"{billId}");

                }
                _DBContext.Bill.Remove(bill);
                await _DBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BackEndDigitalWareException($"Ocurrió un error al eliminar la factura" + $"{billId}" + ex.InnerException.ToString());
            }
        }
    }
}
