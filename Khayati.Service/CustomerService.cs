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

        public async Task<CustomerAddDto> AddCustomer(CustomerAddDto customerAddDto)
        {
            if (customerAddDto == null)
            {
                return null;
            }
            Customer customer = customerAddDto.ToCustomer();
            await _unitOfWork.CustomerRepository.Add(customer);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return customerAddDto;

        }

        public async Task<CustomerResponseDto> GetCustomerById(int? customerId)
        {
            if (customerId == null || customerId == 0)
            {
                return null;
            }
            Customer customer = await _unitOfWork.CustomerRepository
                .GetFirstOrDefault(x => x.CustomerId == customerId);

            CustomerResponseDto CustomerResponseDto = customer.ToCustomerResponseDto();
            return CustomerResponseDto;

        }

     
    }
}