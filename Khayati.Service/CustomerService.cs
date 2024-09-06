using Entities;
using Khayati.ServiceContracts;
using Khayati.ServiceContracts.DTO;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AddCustomerDto> AddCustomer(AddCustomerDto addCustomerDto)
        {
            if (addCustomerDto == null)
            {
                return null;
            }
            Customer customer = addCustomerDto.ToCustomer();
            await _unitOfWork.CustomerRepository.Add(customer);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return addCustomerDto;

        }
    }
}