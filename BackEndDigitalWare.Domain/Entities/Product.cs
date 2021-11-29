using System;

namespace BackEndDigitalWare.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public int MarkId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public bool Availability { get; set; }
        public virtual Mark Mark { get; set; }
    }
}
