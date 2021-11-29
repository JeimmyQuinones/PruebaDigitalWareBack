using BackEndDigitalWare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Domain.Contracts
{
    public interface IDetailBillRepository
    {
        Task<List<DetailBill>> DetailBillByBillIdFindAsync(Guid billId);
        Task DetailBillListAddAsync(List<DetailBill> ListDetail);
        Task DetailBillListUpdateAsync(List<DetailBill> ListDetail);
        Task DetailBillListDeleteAsync(List<DetailBill> ListDetail);
    }
}
