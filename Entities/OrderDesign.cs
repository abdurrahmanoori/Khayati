using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class OrderDesign
    {
        [Key]
        public int DesignId { get; set; }
        public int CustomerId { get; set; }

        public int OrderId { get; set; }
        //public int MeasurementId { get; set; }
        public int EmblishId { get; set; }
                
        public string? ImageUrl { get; set; }
        public string? Notes { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customer { get; set; }
        //public Measurement Measurement { get; set; }
        [ForeignKey(nameof(EmblishId))]
        public virtual Measurement? Emblish { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order? Order { get; set; }
    }

}
