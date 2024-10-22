using Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khayati.Core.DTO
{
    public class OrdersAddDto
    {
        public int CustomerId { get; set; }
        //public int DesignId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedCompletionDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }

       // [ForeignKey(nameof(CustomerId))]
        //public Customer? Customer { get; set; }

        
        public Order ToOrders()
        {
            return new Order
            {
                CustomerId = CustomerId,
                OrderDate = OrderDate,
                //ExpectedCompletionDate=ExpectedCompletionDate,    
                TotalCost = TotalCost,
                //Status=Status,
              //  Customer = Customer

            };
        }

    }
}
