using AutoMapper;
using Entities;
using Khayati.Core.Domain.Entities;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Customers;
using Khayati.Core.DTO.Embellishment;
using Khayati.Core.DTO.EmbellishmentType;
using Khayati.Core.DTO.Fabric;
using Khayati.Core.DTO.GarmentField;
using Khayati.Core.DTO.Garments;
using Khayati.Core.DTO.Measurements;
using Khayati.Core.DTO.Payment;
using Khayati.Core.DTO.Relative;

namespace Khayati.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerResponseDto>();
            CreateMap<Customer, CustomerAddDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<EmbellishmentType, EmbellishmentTypeResponseDto>().ReverseMap();
            CreateMap<EmbellishmentType, EmbellishmentTypeAddDto>().ReverseMap();
            CreateMap<Embellishment, EmbellishmentAddDto>().ReverseMap();
            CreateMap<Embellishment, EmellishmentResponseDetailsDto>().ReverseMap();

            CreateMap<Embellishment, EmbellishmentResponseDto>()
                .ForMember(dest => dest.EmbellishmentName, opt => opt
                .MapFrom(src => src.Name))
                .ForMember(dest => dest.EmbellishmentDiscription, opt => opt
                .MapFrom(src => src.Description))
                .ReverseMap();

            CreateMap<Embellishment, EmbellishmentUpdateDto>().ReverseMap();
            CreateMap<Order, OrdersAddDto>().ReverseMap();

            CreateMap<Relative, RelativeAddDto>().ReverseMap();
            CreateMap<Relative, RelativeResponseDto>().ReverseMap();
            CreateMap<Relative, RelativeDto>().ReverseMap();
            CreateMap<Relative, RelativeUpdateDto>().ReverseMap();
            CreateMap<Customer, CustomerRelativeDto>().ReverseMap();
            CreateMap<Measurement, MeasurementAddDto>().ReverseMap();
            CreateMap<Measurement, MeasurementDto>().ReverseMap();

            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Garment, GarmentDto>().ReverseMap();
            CreateMap<Garment, GarmentAddDto>().ReverseMap();

            //For Fabric 
            CreateMap<Fabric, FabricAddDto>().ReverseMap();
            CreateMap<Fabric, FabricResponseDto>().ReverseMap();

            CreateMap<GarmentFieldAddDto, GarmentField>().ReverseMap();
            CreateMap<GarmentField, GarmentFieldResponseDto>().ReverseMap();
            CreateMap<Order, OrdersResponseDto>().ReverseMap();

        }
    }
}
