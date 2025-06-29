using Khayati.Core.DTO.Measurements;

namespace Khayati.Core.DTO.Customers
{
    public class CustomerResponseDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string NationalID { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public bool IsActive { get; set; }
        public DateTime CustomerSince { get; set; }
        public string CustomerType { get; set; }

        public List<MeasurementDto> Measurements { get; set; }
    }

    //public static class CustomerExtention
    //{
    //    public static CustomerResponseDto ToCustomerResponseDto(this Customer customer)
    //    {
    //        return new CustomerResponseDto
    //        {
    //            CustomerId = customer.CustomerId,
    //            Name = customer.Name,
    //            Address = customer.Address,
    //            PhoneNumber = customer.PhoneNumber,
    //            //CustomerSince = customer.CustomerSince,
    //            DateOfBirth = customer.DateOfBirth,
    //            //CustomerType = customer.CustomerType,
    //            NationalID = customer.NationalID,
    //            EmailAddress = customer.EmailAddress
    //        };
    //    }
    //}
}
