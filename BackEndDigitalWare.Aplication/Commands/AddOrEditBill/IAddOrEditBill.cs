using BackEndDigitalWare.Aplication.Commands.AddNewBill.Models;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Aplication.Commands.AddNewBill
{
    public interface IAddOrEditBill
    {
        Task RunAddOrEditBiil(BillCommansdModel billModel);
    }
}
