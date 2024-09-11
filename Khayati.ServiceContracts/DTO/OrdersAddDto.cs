using Entities;

namespace Khayati.ServiceContracts.DTO
{
    public class OrdersAddDto
    {
        public int CustomerId { get; set; }
        //public int DesignId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedCompletionDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }

        public Customer Customer { get; set; }


        public Orders ToOrders()
        {
            return new Orders
            {
              CustomerId=CustomerId,
              OrderDate=OrderDate,
              ExpectedCompletionDate=ExpectedCompletionDate,    
              TotalCost=TotalCost,  
              Status=Status,
              Customer=Customer
              
            };
        }

    }
}
