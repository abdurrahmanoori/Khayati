using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Customers;

namespace Khayati.ServiceContracts
{
    public interface ICustomerService
    {
        Task<Result<CustomerDto>> AddCustomer(CustomerAddDto dto);
        Task<Result<bool>> UpdateCustomer(int id, CustomerDto dto);
        Task<Result<CustomerResponseDto>> GetCustomerById(int id);
        Task<Result<List<CustomerResponseDto>>> GetCustomerList( );
        Task<Result<bool>> DeleteCustomer(int id);

    }
}
