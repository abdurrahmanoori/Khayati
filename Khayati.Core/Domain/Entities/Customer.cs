using Khayati.Core.Domain.Entities;

namespace Entities
{
    public class Customer: AuditableEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

        // Suggested additional properties:
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string NationalID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public DateTime CustomerSince { get; set; }
        public string CustomerType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Measurement> Measurements { get; set; }



    }

}
