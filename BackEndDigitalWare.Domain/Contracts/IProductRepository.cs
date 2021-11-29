using BackEndDigitalWare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Domain.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> ProductAllAsync();
        Task<Product> ProductByIdFindAsync(int productId);
        Task ProductUpdateAsync(List<Product> product);
    }
}
