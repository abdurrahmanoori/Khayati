using Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public int? OrderId { get; set; }


        [ForeignKey(nameof(OrderId))]
        public virtual Order? Order { get; set; }

        public void PaymentCompleted( )
        {

        }
    }


}
