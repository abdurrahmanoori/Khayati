using AutoMapper;
using Entities;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Customers;
using Khayati.ServiceContracts;
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
        public async Task<Result<CustomerDto>> AddCustomer(CustomerAddDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);
            await _unitOfWork.CustomerRepository.Add(entity);
            await _unitOfWork.SaveChanges();
            return Result<CustomerDto>.SuccessResult(_mapper.Map<CustomerDto>(entity));
        }

        public async Task<Result<bool>> DeleteCustomer(int id)
        {
            var entity = await _unitOfWork.CustomerRepository.GetById(id);
            if (entity == null) return Result<bool>.NotFoundResult(id);

            await _unitOfWork.CustomerRepository.Remove(entity);
            await _unitOfWork.SaveChanges();
            return Result<bool>.SuccessResult(true);
        }

        public async Task<Result<CustomerResponseDto>> GetCustomerById(int id)
        {
            var entity = await _unitOfWork.CustomerRepository
                .GetFirstOrDefault(x => x.CustomerId == id && !x.IsDeleted, includeProperties: "Measurements");
            if (entity == null) return Result<CustomerResponseDto>.NotFoundResult(id);

            return Result<CustomerResponseDto>.SuccessResult(_mapper.Map<CustomerResponseDto>(entity));
        }

        
        public async Task<Result<List<CustomerResponseDto>>> GetCustomerList()
        {
            var list = await _unitOfWork.CustomerRepository.GetAll(x => !x.IsDeleted, includeProperties: "Measurements");

            if (!list.Any()) return Result<List<CustomerResponseDto>>.EmptyResult(nameof(Customer));
            return Result<List<CustomerResponseDto>>.SuccessResult(_mapper.Map<List<CustomerResponseDto>>(list));
        }

        public async Task<Result<bool>> UpdateCustomer(int id, CustomerDto dto)
        {
            var entity = await _unitOfWork.CustomerRepository.GetById(id);
            if (entity == null) return Result<bool>.NotFoundResult(id);

            _mapper.Map(dto, entity);
            await _unitOfWork.SaveChanges();
            return Result<bool>.SuccessResult(true);
        }
    }
}