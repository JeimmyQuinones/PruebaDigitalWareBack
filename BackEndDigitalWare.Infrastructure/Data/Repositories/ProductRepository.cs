using BackEndDigitalWare.Aplication;
using BackEndDigitalWare.Domain.Contracts;
using BackEndDigitalWare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Infrastructure.Data.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly IDBContext _DBContext;
        public ProductRepository(IDBContext DBContext)
        {
            _DBContext = DBContext;
        }
        /// <summary>
        /// Metodo encargado de buscar todos los productos en la base de datos
        /// </summary>
        /// <returns>Lista de productos</returns>
        public async Task<List<Product>> ProductAllAsync()
        {
            try
            {
                return await _DBContext.Product.ToListAsync();
            }
            catch
            {
                throw new BackEndDigitalWareException($"Ocurrió un error al consultar los productos");
            }
        }

        /// <summary>
        /// Metodo encargado de buscar un porducto en la base de datos
        /// </summary>
        /// <param name="name">Nombre del producto</param>
        /// <returns>Objeto producto</returns>
        public async Task<Product> ProductByIdFindAsync(int productId)
        {
            try
            {
                return await _DBContext.Product
                    .AsNoTracking()
                    .FirstOrDefaultAsync(
                    x => x.ProductId.Equals(productId)
                    );
            }
            catch
            {
                throw new BackEndDigitalWareException($"Ocurrió un error al consultar el producto" + $"{productId}.");
            }
        }
        /// <summary>
        /// Metodo encargado de actualizar un producto en la base de datos
        /// </summary>
        /// <param name="product">Objeto Factura</param>
        /// <returns></returns>
        public async Task ProductUpdateAsync(List<Product> product)
        {
            try
            {
                _DBContext.Product.UpdateRange(product);
                await _DBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _DBContext.Product.RemoveRange(product);
                throw new BackEndDigitalWareException($"Ocurrió un error al actualizar el producto" + $"{product}" + ex.InnerException.ToString());
            }
        }
    }
}
