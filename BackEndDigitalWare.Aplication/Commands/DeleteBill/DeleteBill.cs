using BackEndDigitalWare.Domain.Contracts;
using System;
using System.Threading.Tasks;

namespace BackEndDigitalWare.Aplication.Commands.DeleteBill
{
    public class DeleteBill: IDeleteBill
    {
        private readonly IBillRepository _billRepository;
        private readonly IDetailBillRepository _detailBillRepository;

        public DeleteBill( IBillRepository billRepository,
            IDetailBillRepository detailBillRepository)
        {
            _detailBillRepository = detailBillRepository;
            _billRepository = billRepository;
        }
        /// <summary>
        /// Metodo encargado de eliminar la Factura con sus correspondientes detalles
        /// </summary>
        /// <param name="billId">Identificación de la factura</param>
        /// <returns></returns>
        public async Task RunDeleteBill(Guid billId)
        {
            var FindBill = await _billRepository.BillByIdFindAsync(billId);
            if (FindBill != null)
            {
                var detailsBill= await _detailBillRepository.DetailBillByBillIdFindAsync(billId);
                if (detailsBill.Count != 0)
                {
                    await _detailBillRepository.DetailBillListDeleteAsync(detailsBill);
                }
                await _billRepository.BillDeleteAsync(billId);
            }
        }
    }
}
