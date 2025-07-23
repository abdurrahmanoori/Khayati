using Entities.Enum;
using Khayati.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        /// <summary>
        /// This property indicates when the tailor is expected to complete the sewing.
        /// </summary>
        public DateTime? ExpectedCompletionDate { get; set; }

        /// <summary>
        /// The cost charged by the tailor for sewing the clothes.
        /// </summary>
        public decimal? Cost { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime OrderDate { get; set; }

        public bool IsPaid { get; set; }
        public string? Notes { get; set; }

        // Sum of all payments made for this order
        public decimal AmountPaid => Payments?.Sum(p => p.Amount) ?? 0;
        public decimal? RemainingAmount => TotalCost - (Payments?.Sum(p => p.Amount) ?? 0);

        public OrderStatus OrderStatus { get; set; }

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;

        public OrderPriority OrderPriority { get; set; } = OrderPriority.Normal;

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
        public virtual List<OrderGarment>? OrderGarments { get; set; }
        public void CalculateOrderStatus( )
        {

        }

        public void CalculatePaymentStatus( )
        {
            if (AmountPaid == 0)
            {
                PaymentStatus = PaymentStatus.Unpaid;
                IsPaid = false;
            }
            else if (AmountPaid >= TotalCost)
            {
                PaymentStatus = PaymentStatus.Paid;
                IsPaid = true;
                //OrderDate = DateTime.UtcNow;
            }
            else
            {
                PaymentStatus = PaymentStatus.Partial;
                IsPaid = false;
                //OrderDate = DateTime.UtcNow;
            }
        }

        public bool IsValidOrderForPayment( )
        {
            if (TotalCost == 0 && OrderStatus != OrderStatus.Completed)
                return true;

            return false;
        }

    }
}