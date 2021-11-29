using BackEndDigitalWare.Aplication;
using BackEndDigitalWare.Domain.Contracts;
using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Infrastructure.Data.Repositories
{
    public class IdentificationTypeRepository: IIdentificationTypeRepository
    {
        private readonly IDBContext _DBContext;
        public IdentificationTypeRepository(IDBContext DBContext)
        {
            _DBContext = DBContext;
        }

        /// <summary>
        /// Metodo encargado de buscar a todos los tipos de identificaión en la base de datos
        /// </summary>
        /// <returns>Lista de Tipos de identificación</returns>
        public async Task<List<IdentificationType>> IdentificationTypeAllAsync()
        {
            try
            {
                return await _DBContext.IdentificationType.ToListAsync();
            }
            catch
            {
                throw new BackEndDigitalWareException($"Ocurrió un error al consultar los tipos de identificación");
            }
        }
    }
}
