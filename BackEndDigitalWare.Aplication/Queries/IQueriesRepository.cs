using BackEndDigitalWare.Aplication.Queries.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Aplication.Queries
{
    public interface IQueriesRepository
    {
        Task<List<BillWithCustomer>> GetListBillWithCustomer();
        Task<List<DetailBillByBillId>> GetListDetailBillByBillId(Guid billId);
        Task<CustomerInfo> GetCustomerByDocumentAndType(int identificationType, string documentNumber);
    }
}
