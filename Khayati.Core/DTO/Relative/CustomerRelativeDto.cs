using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.DTO.Relative
{
    public class CustomerRelativeDto
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
        //public bool IsActive { get; set; }
        //public string? CustomerType { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
        //public virtual ICollection<Measurement> Measurements { get; set; }
        //public virtual ICollection<Relative> Relatives { get; set; }  // New relationship to track relatives


    }
}
