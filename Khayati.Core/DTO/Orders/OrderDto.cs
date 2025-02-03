
using Khayati.Core.DTO.Customers;
using Khayati.Core.DTO.Payment;

namespace Khayati.Core.DTO.Orders
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        /// <summary>
        /// This property indicates when the tailor is expected to complete the sewing.
        /// </summary>
        public DateTime? ExpectedCompletionDate { get; set; }

        public decimal? TotalCost { get; set; }
        public DateTime OrderDate { get; set; }

        public bool IsPaid { get; set; }

        // Sum of all payments made for this order
        public decimal AmountPaid { get; set; }
        public decimal? RemainingAmount { get; set; }
        //public OrderStatus OrderStatus { get; set; }

        //public PaymentStatus PaymentStatus { get; set; }
        public CustomerDto? CustomerDto { get; set; }
        public ICollection<PaymentDto>? PaymentDtos { get; set; }
        //public virtual ICollection<OrderDesign> OrderDesigns { get; set; }


      
    }
}
