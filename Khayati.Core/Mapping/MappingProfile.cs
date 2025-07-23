using AutoMapper;
using Entities;
using Entities.Enum;
using Khayati.Core.Domain.Entities;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Customers;
using Khayati.Core.DTO.Embellishment;
using Khayati.Core.DTO.EmbellishmentType;
using Khayati.Core.DTO.Fabric;
using Khayati.Core.DTO.GarmentField;
using Khayati.Core.DTO.Garments;
using Khayati.Core.DTO.Measurements;
using Khayati.Core.DTO.OrderGarmentEmbellishments;
using Khayati.Core.DTO.OrderGarments;
using Khayati.Core.DTO.Orders;
using Khayati.Core.DTO.payment;
using Khayati.Core.DTO.Relative;
using Khayati.Core.Enums;

namespace Khayati.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile( )
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


            CreateMap<Order, OrderResponseDto>()
               .ForMember(dest => dest.OrderStatus,
                          opt => opt.MapFrom(src => src.OrderStatus.ToString()))
               .ForMember(dest => dest.PaymentStatus,
                  opt => opt.MapFrom(src => src.PaymentStatus.ToString()))
               .ForMember(dest => dest.OrderPriority,
                  opt => opt.MapFrom(src => src.OrderPriority.ToString()))
           .ReverseMap()
               .ForMember(dest => dest.OrderStatus,
                          opt => opt.MapFrom(src => ParseOrderStatus(src.OrderStatus)))
               .ForMember(dest => dest.PaymentStatus,
                      opt => opt.MapFrom(src => ParsePaymentStatus(src.PaymentStatus)))
               .ForMember(dest => dest.OrderPriority,
                      opt => opt.MapFrom(src => ParseOrderPriority(src.OrderPriority)));


            CreateMap<OrderGarmentEmbellishment, OrderGarmentEmbellishmentDto>().ReverseMap();

            CreateMap<Relative, RelativeAddDto>().ReverseMap();
            CreateMap<Relative, RelativeResponseDto>().ReverseMap();
            CreateMap<Relative, RelativeDto>().ReverseMap();
            CreateMap<Relative, RelativeUpdateDto>().ReverseMap();
            CreateMap<Customer, CustomerRelativeDto>().ReverseMap();
            CreateMap<Measurement, MeasurementAddDto>().ReverseMap();
            CreateMap<Measurement, MeasurementDto>().ReverseMap();

            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Garment, GarmentDto>().ReverseMap();

            CreateMap<OrderGarment, OrderGarmentDto>()
                           .ForMember(dest => dest.ProductionStatus,
                          opt => opt.MapFrom(src => src.ProductionStatus.ToString()))
                         .ReverseMap()
                   .ForMember(dest => dest.ProductionStatus,
                      opt => opt.MapFrom(src => ParseOrderPriority(src.ProductionStatus)));




            CreateMap<Garment, GarmentAddDto>().ReverseMap();

            //For Fabric 
            CreateMap<Fabric, FabricAddDto>().ReverseMap();
            CreateMap<Fabric, FabricResponseDto>().ReverseMap();

            CreateMap<GarmentFieldAddDto, GarmentField>().ReverseMap();
            CreateMap<GarmentField, GarmentFieldResponseDto>().ReverseMap();
            CreateMap<Order, OrdersResponseDto>().ReverseMap();

        }
        private static OrderStatus ParseOrderStatus(string status)
        {
            return Enum.TryParse<OrderStatus>(status, true, out var parsed)
                ? parsed
                : OrderStatus.Pending; // default fallback
        }

        private static PaymentStatus ParsePaymentStatus(string status)
        {
            return Enum.TryParse<PaymentStatus>(status, true, out var result)
                ? result
                : PaymentStatus.Unpaid; // or a safe default
        }

        private static OrderPriority ParseOrderPriority(string status)
        {
            return Enum.TryParse<OrderPriority>(status, true, out var result)
                ? result
                : OrderPriority.Normal; // or a safe default
        }
        private static ProductionStatus ParseProductionStatus(string status)
        {
            return Enum.TryParse<ProductionStatus>(status, true, out var result)
                ? result
                : ProductionStatus.Pending; // or a safe default
        }


    }
}
