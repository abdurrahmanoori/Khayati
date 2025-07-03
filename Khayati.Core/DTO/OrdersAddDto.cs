using Entities.Enum;
using Khayati.Core.DTO.OrderDesign;
using Khayati.Core.DTO.Payment;
using Khayati.Core.Enums;

namespace Khayati.Core.DTO
{
    public class OrdersAddDto
    {
        public int CustomerId { get; set; }
        /// <summary>
        /// This property indicates when the tailor is expected to complete the sewing.
        /// </summary>
        public DateTime? ExpectedCompletionDate { get; set; }
        public decimal? Cost { get; set; }

        public decimal? TotalCost { get; set; }
        public DateTime OrderDate { get; set; }

        public bool IsPaid { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public OrderPriority OrderPriority { get; set; } = OrderPriority.Normal;

        public virtual ICollection<OrderDesignAddDto>? OrderDesigns { get; set; }
        public virtual ICollection<PaymentDto>? Payments { get; set; }




        // Sum of all payments made for this order
        //public decimal AmountPaid => Payments?.Sum(p => p.Amount) ?? 0;
        //public decimal? RemainingAmount => TotalCost - (Payments?.Sum(p => p.Amount) ?? 0);

    }
}
