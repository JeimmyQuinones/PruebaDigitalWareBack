using System;

namespace BackEndDigitalWare.Domain.Entities
{
    public class DetailBill
    {
        public Guid DetailBillId { get; set; }
        public Guid BillId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
