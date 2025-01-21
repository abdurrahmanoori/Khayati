using Khayati.Core.Common;
using Khayati.Core.Domain.Entities;

namespace Entities
{
    public class Customer : AuditableEntity
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        // Suggested additional properties:
        public string PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? NationalID { get; set; }
        public DateTime DateOfBirth { get; set; }
       // public bool IsActive { get; set; }
        //public string? CustomerType { get; set; }

        public virtual IList<Order> Orders { get; set; }
        public virtual IList<Measurement> Measurements { get; set; }
        public virtual IList<Relative> Relatives { get; set; }  // New relationship to track relatives




    }

}
