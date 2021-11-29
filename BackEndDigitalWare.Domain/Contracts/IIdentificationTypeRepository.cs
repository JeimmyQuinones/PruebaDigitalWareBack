using BackEndDigitalWare.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Domain.Contracts
{
    public interface IIdentificationTypeRepository
    {
        Task<List<IdentificationType>> IdentificationTypeAllAsync();
    }
}
