using Entities.Enum;
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

        public decimal? TotalCost { get; set; }
        public DateTime OrderDate { get; set; }
       
        public bool IsPaid { get; set; }

        // Sum of all payments made for this order
        public decimal AmountPaid => Payments?.Sum(p => p.Amount) ?? 0;
        public decimal? RemainingAmount => TotalCost - (Payments?.Sum(p => p.Amount) ?? 0);
        //public decimal? RemainingAmount => TotalCost - Payments.Sum(p => p.Amount);

        public string OrderStatus { get; set; }

        // Status of the overall payment (Completed, Partial, etc.)
        public PaymentStatus PaymentStatus
        {
            get
            {
                if (AmountPaid == 0) return PaymentStatus.Pending;
                if (AmountPaid >= TotalCost) return PaymentStatus.Completed;
                return PaymentStatus.PartialPayment;
            }
        }


        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
        public virtual ICollection<OrderDesign> OrderDesigns { get; set; }
    }
}





//To implement partial payment functionality, you can enhance your current Payment entity by tracking multiple partial payments associated with a specific order and calculating the remaining amount. Here's how you can approach it:
//1. Add a TotalAmount field to the Order entity:

//This will store the total amount due for the order, against which the payments (including partial payments) will be made.
//2. Modify the Payment entity:

//    You can track partial payments using the Amount field for each individual payment.
//    Add a RemainingAmount property to the Order to calculate how much is left to pay.
//    Add a collection of Payment records to the Order entity to keep track of all payments.

//Example:
//Order Class:

//csharp

//public class Order
//{
//    [Key]
//    public int OrderId { get; set; }

//    public decimal TotalAmount { get; set; }

//    public decimal RemainingAmount => TotalAmount - Payments.Sum(p => p.Amount);

//    public virtual ICollection<Payment> Payments { get; set; }
//}

//Updated Payment Class:

//csharp

//public class Payment
//{
//    [Key]
//    public int PaymentId { get; set; }

//    public decimal Amount { get; set; }

//    public DateTime PaymentDate { get; set; }

//    public int? OrderId { get; set; }

//    public PaymentStatus PaymentStatus { get; set; }

//    [ForeignKey(nameof(OrderId))]
//    public virtual Order? Order { get; set; }
//}

//3.Track Partial Payments:

//Each Payment entry records the amount paid and can be marked with the PartialPayment status. The remaining amount can be dynamically calculated based on the sum of all payments associated with the order.
//4. Business Logic for Partial Payment:

//You will need business logic to handle the following:

//    When a new payment is made, check the total amount paid so far.
//    If the total paid equals or exceeds the TotalAmount, mark the payment as Completed.
//    If the total paid is less than TotalAmount, keep the status as PartialPayment.

//Example Logic:

//csharp

//public void ProcessPayment(Order order, decimal paymentAmount)
//{
//    var payment = new Payment
//    {
//        Amount = paymentAmount,
//        PaymentDate = DateTime.Now,
//        PaymentStatus = PaymentStatus.PartialPayment,
//        OrderId = order.OrderId
//    };

//    order.Payments.Add(payment);

//    if (order.RemainingAmount == 0)
//    {
//        payment.PaymentStatus = PaymentStatus.Completed;
//    }
//    else if (order.RemainingAmount < order.TotalAmount)
//    {
//        payment.PaymentStatus = PaymentStatus.PartialPayment;
//    }

//    // Save payment to database (e.g., via Unit of Work/Repository pattern)
//}

//This approach allows you to track the amount paid for each order and calculate the remaining balance easily.