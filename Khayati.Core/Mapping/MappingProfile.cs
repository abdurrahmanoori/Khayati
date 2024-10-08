using AutoMapper;
using Entities;
using Khayati.ServiceContracts.DTO;

namespace Khayati.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerResponseDto>();
        }
    }
}
