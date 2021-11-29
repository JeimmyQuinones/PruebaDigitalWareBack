using BackEndDigitalWare.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Domain.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer> BillByIdFindAsync(string documentNumber);
        Task<List<Customer>> CustomerAllAsync();
    }
}
