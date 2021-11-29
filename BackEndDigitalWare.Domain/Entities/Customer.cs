using System;

namespace BackEndDigitalWare.Domain.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public short IdentificationTypeId { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
        public virtual IdentificationType IdentificationType { get;set;}
    }
}
