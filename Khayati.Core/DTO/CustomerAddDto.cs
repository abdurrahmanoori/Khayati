using Entities;

namespace Khayati.Core.DTO
{
    public class CustomerAddDto
    {
        public string Name { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string NationalID { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public bool IsActive { get; set; }
        public DateTime CustomerSince { get; set; }
        public string CustomerType { get; set; }


        public Customer ToCustomer()
        {
            return new Customer
            {
                Name = Name,
                Address = Address,
                PhoneNumber = PhoneNumber,
                //CustomerSince = CustomerSince,
                DateOfBirth = DateOfBirth,
                //CustomerType = CustomerType,
                NationalID = NationalID,
                EmailAddress = EmailAddress

            };
        }

    }
}
