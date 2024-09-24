using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.ServiceContracts.DTO
{
    public class CustomerResponseDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string NationalID { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public bool IsActive { get; set; }
        public DateTime CustomerSince { get; set; }
        public string CustomerType { get; set; }
    }

    public static class CustomerExtention
    {
        public static CustomerResponseDto ToCustomerResponseDto(this Customer customer)
        {
            return new CustomerResponseDto
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                CustomerAddress = customer.CustomerAddress,
                PhoneNumber = customer.PhoneNumber,
                CustomerSince = customer.CustomerSince,
                DateOfBirth = customer.DateOfBirth,
                CustomerType = customer.CustomerType,
                NationalID = customer.NationalID,
                EmailAddress = customer.EmailAddress
            };
        }
    }
}
