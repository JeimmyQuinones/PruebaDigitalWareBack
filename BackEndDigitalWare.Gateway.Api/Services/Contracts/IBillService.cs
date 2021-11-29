using BackEndDigitalWare.Aplication.Queries.Models;
using BackEndDigitalWare.Gateway.Api.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Gateway.Api.Services.Contracts
{
    public interface IBillService
    {
        Task<List<BillWithCustomer>> FindBillList();
        Task<List<DetailBillByBillId>> FindDetailBillList(string billId);
        Task DeleteBillAndDetailOfBills(string billId);
        Task CreateOrEditBills(BillAddViewModel billModel);
        Task<CustomerInfo> FindCustomer(int identificationType, string documentNumber);
    }
}
