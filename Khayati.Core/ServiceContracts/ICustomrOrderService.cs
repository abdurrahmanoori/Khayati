using Khayati.Core.Common.Response;
using Khayati.Core.DTO;

namespace Khayati.ServiceContracts
{
    public interface ICustomrOrderService
    {
        Task<BaseCommandResponse<CustomerAddDto>> CreateCustomerOrder(
            CustomerAddDto customer,
            MeasurementAddDto measurement
            , OrdersAddDto order);

        //public Task<OrdersAddDto> AddOrders(OrdersAddDto addOrdersDto);


    }
}
