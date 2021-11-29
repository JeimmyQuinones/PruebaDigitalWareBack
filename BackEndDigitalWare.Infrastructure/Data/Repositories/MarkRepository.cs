using BackEndDigitalWare.Aplication;
using BackEndDigitalWare.Domain.Contracts;
using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Infrastructure.Data.Repositories
{
    public class MarkRepository: IMarkRepository
    {
        private readonly IDBContext _DBContext;
        public MarkRepository(IDBContext DBContext)
        {
            _DBContext = DBContext;
        }
        /// <summary>
        /// Metodo encargado de buscar a todas las marcas en la base de datos
        /// </summary>
        /// <returns>Lista de marcas</returns>
        public async Task<List<Mark>> MarksAllAsync()
        {
            try
            {
                return await _DBContext.Mark.ToListAsync();
            }
            catch
            {
                throw new BackEndDigitalWareException($"Ocurrió un error al consultar las marcas");
            }
        }
    }
}
