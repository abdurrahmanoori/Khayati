using Khayati.ServiceContracts.DTO;

namespace Khayati.ServiceContracts
{
    public interface ICustomerService
    {
        public Task<AddCustomerDto> AddCustomer(AddCustomerDto addCustomerDto);

    }
}
