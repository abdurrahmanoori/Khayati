using AutoMapper;
using Entities;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Embellishments;
using Khayati.Core.DTO.EmbellishmentType;
using Khayati.Core.DTO.OrderDesign;

namespace Khayati.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerResponseDto>();
            CreateMap<Customer, CustomerAddDto>().ReverseMap();
            CreateMap<EmbellishmentType, EmbellishmentTypeResponseDto>().ReverseMap();
            CreateMap<Embellishment, EmbellishmentAddDto>().ReverseMap();
            CreateMap<Order, OrdersAddDto>().ReverseMap();
            CreateMap<OrderDesign, OrderDesignAddDto>().ReverseMap();
            CreateMap<Measurement, MeasurementAddDto>().ReverseMap();
       
            // CreateMap<EmbellishmentType, EmbellishmentTypeResponseDto>();




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
