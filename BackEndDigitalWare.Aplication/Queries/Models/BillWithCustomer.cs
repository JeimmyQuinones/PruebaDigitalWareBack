using System;

namespace BackEndDigitalWare.Aplication.Queries.Models
{
    public class BillWithCustomer
    {
        public Guid BillId { get; set; }
        public Guid CustomerId { get; set; }
        public string IdentificationNumber { get; set; }
        public string Synonymous { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
    }
}
