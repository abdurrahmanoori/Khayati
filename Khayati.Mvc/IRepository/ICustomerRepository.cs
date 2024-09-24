using Khayati.ServiceContracts.DTO;

namespace Khayati.Mvc.IRepository
{
    public interface ICustomerRepository
    {
        Task<CustomerResponseDto> GetCustomerResponseList();
    }
}
