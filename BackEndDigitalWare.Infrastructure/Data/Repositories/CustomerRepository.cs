using BackEndDigitalWare.Aplication;
using BackEndDigitalWare.Domain.Contracts;
using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Infrastructure.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly IDBContext _DBContext;
        public CustomerRepository(IDBContext DBContext)
        {
            _DBContext = DBContext;
        }
        /// <summary>
        /// Metodo encargado de buscar un cliente en la base de datos
        /// </summary>
        /// <param name="documentNumber">Numero de identificacion del cliente</param>
        /// <returns>Objeto Cliente</returns>
        public async Task<Customer> BillByIdFindAsync(string documentNumber)
        {
            try
            {
                return await _DBContext.Customer
                    .AsNoTracking()
                    .FirstOrDefaultAsync(
                    x => x.IdentificationNumber.Equals(documentNumber)
                    );
            }
            catch
            {
                throw new BackEndDigitalWareException($"Ocurrió un error al consultar el cliente" + $"{documentNumber}.");
            }
        }

        /// <summary>
        /// Metodo encargado de buscar a todos los clientes en la base de datos
        /// </summary>
        /// <returns>Lista de clientes</returns>
        public async Task<List<Customer>> CustomerAllAsync()
        {
            try
            {
                return await _DBContext.Customer.ToListAsync();
            }
            catch
            {
                throw new BackEndDigitalWareException($"Ocurrió un error al consultar los clientes");
            }
        }
    }
}
