using AutoMapper;
using Entities;
using Khayati.ServiceContracts;
using Khayati.Core.DTO;
using RepositoryContracts.Base;
using Khayati.Core.DTO.Customers;
using Khayati.Core.Common.Response;

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
        public async Task<Result<CustomerAddDto>> AddCustomer(CustomerAddDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);
            await _unitOfWork.CustomerRepository.Add(entity);
            await _unitOfWork.SaveChanges();
            return Result<CustomerAddDto>.SuccessResult(_mapper.Map<CustomerAddDto>(entity));
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
                .GetFirstOrDefault(x => x.CustomerId == id, includeProperties: "Orders,Measurements,Relatives");
            if (entity == null) return Result<CustomerResponseDto>.NotFoundResult(id);

            return Result<CustomerResponseDto>.SuccessResult(_mapper.Map<CustomerResponseDto>(entity));
        }


        public async Task<Result<List<CustomerResponseDto>>> GetCustomerList( )
        {
            var list = await _unitOfWork.CustomerRepository.GetAll(includeProperties: "Orders,Measurements,Relatives");

            if (!list.Any()) return Result<List<CustomerResponseDto>>.EmptyResult(nameof(Customer));
            return Result<List<CustomerResponseDto>>.SuccessResult(_mapper.Map<List<CustomerResponseDto>>(list));
        }

        public async Task<Result<bool>> UpdateCustomer(int id, CustomerAddDto dto)
        {
            var entity = await _unitOfWork.CustomerRepository.GetById(id);
            if (entity == null) return Result<bool>.NotFoundResult(id);

            _mapper.Map(dto, entity);
            await _unitOfWork.SaveChanges();
            return Result<bool>.SuccessResult(true);
        }
    }
}