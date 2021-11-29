using BackEndDigitalWare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Domain.Contracts
{
    public interface IBillRepository
    {
        Task<Bill> BillByIdFindAsync(Guid billId);
        Task<List<Bill>> BillAllAsync();
        Task BillAddAsync(Bill bill);
        Task BillUpdateAsync(Bill bill);
        Task BillDeleteAsync(Guid billId);
    }
}
