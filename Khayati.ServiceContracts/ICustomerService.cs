using Khayati.ServiceContracts.DTO;

namespace Khayati.ServiceContracts
{
    public interface ICustomerService
    {
        public Task<CustomerAddDto> AddCustomer(CustomerAddDto addCustomerDto);
        public Task<CustomerResponseDto> GetCustomerById(int? customerId);

        public Task<IEnumerable<CustomerResponseDto>> GetCustomerList();

        public Task<CustomerResponseDto> DeleteCustomer(int? customerId);

    }
}
