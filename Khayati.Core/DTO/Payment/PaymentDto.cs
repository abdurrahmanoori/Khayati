namespace Khayati.Core.DTO.payment
{
    public class PaymentDto
    {
        //public int PaymentId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public int? OrderId { get; set; }
        /// <summary>
        /// You could add a PaymentStatus in Payment if you want to track 
        /// the status of each payment individually, but it’s not required 
        /// unless you need detailed payment tracking.
        /// </summary>
        //public PaymentStatus PaymentStatus { get; set; }

        //[ForeignKey(nameof(OrderId))]
        //public virtual Order? Order { get; set; }
    }
}
