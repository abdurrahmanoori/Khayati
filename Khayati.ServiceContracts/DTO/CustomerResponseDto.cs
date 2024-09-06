using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.ServiceContracts.DTO
{
    public class CustomerResponseDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }
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
            };
        }
    }
}
