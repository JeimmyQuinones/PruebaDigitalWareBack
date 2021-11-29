using System;
using System.Collections.Generic;

namespace BackEndDigitalWare.Gateway.Api.ViewModels
{
    public class BillAddViewModel
    {
        public string BillId { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public List<DetalleAddViewModel> ListDetalleAddViewModel { get; set; }
    }
    public class DetalleAddViewModel
    {
        public string DetailBillId { get; set; }
        public string BillId { get; set; }
        public string ProductId { get; set; }
        public int Amount { get; set; }
    }
}
