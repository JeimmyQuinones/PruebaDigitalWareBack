using System;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Aplication.Commands.DeleteBill
{
    public interface IDeleteBill
    {
        Task RunDeleteBill(Guid billId);
    }
}
