using AutoMapper;
using Entities;
using Khayati.Core.DTO;
using Khayati.Core.DTO.EmbellishmentType;

namespace Khayati.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerResponseDto>();
            CreateMap<EmbellishmentType, EmbellishmentTypeResponseDto>().ReverseMap();
           // CreateMap<EmbellishmentType, EmbellishmentTypeResponseDto>();
        }
    }
}
