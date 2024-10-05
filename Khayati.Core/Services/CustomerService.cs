using AutoMapper;
using Entities;
using Khayati.ServiceContracts;
using Khayati.ServiceContracts.DTO;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public async Task<CustomerResponseDto> DeleteCustomer(int? customerId)
        {
            if (!customerId.HasValue)
            {
                return null;
            }
            Customer customer = await _unitOfWork.CustomerRepository.GetById((int)customerId);
            if (customer == null)
            {
                return null;
            }
            await _unitOfWork.CustomerRepository.Remove(customer);
            await _unitOfWork.SaveChanges(default);

            return customer.ToCustomerResponseDto();

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

        public async Task<IEnumerable<CustomerResponseDto>> GetCustomerList()
        {
            IEnumerable<Customer> customers = await _unitOfWork.CustomerRepository.GetAll();
            if (customers is null)
            {
                return null;
            }

            var customerResponseDtos = _mapper.Map<IEnumerable<CustomerResponseDto>>(customers);

            //IEnumerable<CustomerResponseDto> customerResponseDtos = customers
            //    .Select(temp => temp.ToCustomerResponseDto());

            return customerResponseDtos;

        }

    }
}