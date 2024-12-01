using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.DTO.Customers
{
    public class CustomerDto
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
    }
}
