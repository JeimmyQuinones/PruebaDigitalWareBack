using System;

namespace BackEndDigitalWare.Domain.Entities
{
    public class Bill
    {
        public Guid BillId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
