using Khayati.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class OrderGarmentFabric
    {
        [Key]
        public int OrderGarmentId { get; set; }
        public int? FabricId { get; set; }

        /// <summary>
        /// If different designs can have different prices based on the Embellishment or 
        /// customizations applied, a CostAtTimeOfOrder field in the OrderDesigns table is useful. 
        /// This allows for flexibility in pricing models where designs might have additional costs.
        /// if Fabric.CostPerMeter changes later, this preserves order's original cost.
        /// </summary>
        /// 
        public decimal? CostAtTimeOfOrder { get; set; }
        /// <summary>
        /// How many meters (or yards) of the fabric were used in this specific order.
        /// </summary>
        public float? QuantityUsed { get; set; }
        ///// <summary>
        ///// Date fabric was cut for this order — useful for production tracking.
        ///// </summary>
        //public DateTime? CutDate { get; set; }

        public string? Notes { get; set; }


        [ForeignKey(nameof(FabricId))]
        public Fabric? Fabric { get; set; }

        [ForeignKey(nameof(OrderGarmentId))]
        public OrderGarment OrderGarment { get; set; }
    }

}
