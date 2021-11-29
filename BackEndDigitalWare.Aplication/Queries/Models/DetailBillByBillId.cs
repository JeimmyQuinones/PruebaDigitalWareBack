using System;

namespace BackEndDigitalWare.Aplication.Queries.Models
{
    public class DetailBillByBillId
    {
        public Guid DetailBillId { get; set; }
        public Guid BillId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public string ProductName { get; set; }
        public string MarkName { get; set; }
        public short MarkId { get; set; }
        public decimal Price { get; set; }
    }
}
