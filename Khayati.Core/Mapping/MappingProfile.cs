using AutoMapper;
using Entities;
using Khayati.Core.Domain.Entities;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Embellishments;
using Khayati.Core.DTO.EmbellishmentType;
using Khayati.Core.DTO.OrderDesign;
using Khayati.Core.DTO.Relative;

namespace Khayati.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile( )
        {
            CreateMap<Customer, CustomerResponseDto>();
            CreateMap<Customer, CustomerAddDto>().ReverseMap();
            CreateMap<EmbellishmentType, EmbellishmentTypeResponseDto>().ReverseMap();
            CreateMap<Embellishment, EmbellishmentAddDto>().ReverseMap();

            CreateMap<Embellishment, EmbellishmentResponseDto>()
                .ForMember(dest => dest.EmbellishmentName, opt => opt
                .MapFrom(src => src.Name))
                .ForMember(dest => dest.EmbellishmentDiscription, opt => opt
                .MapFrom(src => src.Description))
                .ReverseMap();

            CreateMap<Embellishment, EmbellishmentUpdateDto>().ReverseMap();
            CreateMap<Order, OrdersAddDto>().ReverseMap();
            CreateMap<OrderDesign, OrderDesignAddDto>().ReverseMap();
            CreateMap<Measurement, MeasurementAddDto>().ReverseMap();

            CreateMap<Relative, RelativeAddDto>().ReverseMap();
            CreateMap<Relative, RelativeResponseDto>().ReverseMap();
            CreateMap<Relative, RelativeDto>().ReverseMap();
            CreateMap<Customer, CustomerRelativeDto>().ReverseMap();

            // CreateMap<EmbellishmentType, EmbellishmentTypeResponseDto>();





            //CreateMap<Doctor, DoctorDetailsDto>()
            //    .ForMember(dest => dest.ProvinceName, opt => opt.MapFrom(src => src.Province.Name))
            //    .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
            //    .ForMember(dest => dest.CurrentProvinceName, opt => opt.MapFrom(src => src.Province.Id == src.CurrentProvinceId ? src.Province.Name : ""))
            //    .ForMember(dest => dest.CurrentDistrictName, opt => opt.MapFrom(src => src.District.Id == src.CurrentDistrictId ? "test": src.District.Name))
            //    .ForMember(dest => dest.ProvinceId, opt => opt.MapFrom(src => src.Province.Id))
            //    .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.District.Id))
            //    .ForMember(dest => dest.CurrentProvinceId, opt => opt.MapFrom(src => src.CurrentProvinceId))
            //    .ForMember(dest => dest.CurrentDistrictId, opt => opt.MapFrom(src => src.CurrentDistrictId))
            //    .ReverseMap();

            //CreateMap<Doctor, DoctorDetailsDto>()
            //  .ForMember(dest => dest.CurrentProvinceName, opt => opt.MapFrom(src => src.Province.Name))
            //  .ForMember(dest => dest.CurrentDistrictName, opt => opt.MapFrom(src => src.District.Name))
            //  .ReverseMap();

            //// Mapping from DTO to Entity
            ////CreateMap<CustomerAddDto, Customer>().ReverseMap(); // Add this line
            //CreateMap<MeasurementAddDto, Measurement>(); // Add this line
            //CreateMap<OrdersAddDto, Order>(); // Add this line

            //// Mapping from Entity to DTO and vice versa
            ////CreateMap<Customer, CustomerResponseDto>();
            ////CreateMap<Customer, CustomerAddDto>().ReverseMap(); // ReverseMap for bidirectional mapping
            //CreateMap<EmbellishmentType, EmbellishmentTypeResponseDto>().ReverseMap();
            //CreateMap<Order, OrdersAddDto>().ReverseMap();
            //CreateMap<OrderDesign, OrderDesignAddDto>().ReverseMap();
            //CreateMap<Measurement, MeasurementAddDto>().ReverseMap();
        }
    }
}
