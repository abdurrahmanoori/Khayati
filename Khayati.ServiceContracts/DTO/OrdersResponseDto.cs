using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.ServiceContracts.DTO
{
    public class OrdersResponseDto
    {
        public int OrdersId { get; set; }
        //public int DesignId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedCompletionDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }

        public Order Orders { get; set; }
    }

    public static class OrdersExtention
    {
        public static OrdersResponseDto ToOrdersResponseDto(this Order Orders)
        {
            return new OrdersResponseDto
            {
                OrdersId = Orders.OrderId,
                OrderDate = Orders.OrderDate,
                ExpectedCompletionDate = Orders.ExpectedCompletionDate,
                TotalCost = Orders.TotalCost,
                //Status = Orders.Status,
                Orders = Orders
                
            };
        }
    }
}
