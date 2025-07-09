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
        //public string CustomerType { get; set; }

        public List<MeasurementDto> Measurements { get; set; }
    }
}
