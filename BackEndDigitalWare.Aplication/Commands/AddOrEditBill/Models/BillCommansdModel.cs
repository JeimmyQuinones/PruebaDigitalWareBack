using System;
using System.Collections.Generic;

namespace BackEndDigitalWare.Aplication.Commands.AddNewBill.Models
{
    public class BillCommansdModel
    {
        public string BillId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public List<Detail> ListDetalleAddViewModel { get; set; }
    }
    public class Detail
    {
        public string DetailBillId { get; set; }
        public string BillId { get; set; }
        public string ProductId { get; set; }
        public int Amount { get; set; }
    }
}
