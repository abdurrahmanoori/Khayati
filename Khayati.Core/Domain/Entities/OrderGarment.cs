using Khayati.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class OrderGarment
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public int? GarmentId { get; set; }
        /// <summary>
        /// Number of this specific garment ordered (e.g., 2 jackets). Essential for costing, inventory, and production planning.
        /// </summary>
        public int? Quantity { get; set; }

        public decimal? CostAtTimeOfOrder { get; set; }
        /// <summary>
        /// Indicates if this is the primary focus of the order (e.g., a wedding dress among accessories). Useful for filtering.
        /// </summary>
        public bool? IsMainGarment { get; set; }
        /// <summary>
        /// Status tracking like "Pending", "Cutting", "Stitching", "Ready". Improves workflow management.
        /// </summary>
        public string? ProductionStatus { get; set; }
        /// <summary>
        /// When the garment was cut. Important milestone in production timeline.
        /// </summary>
        public DateTime? CutDate { get; set; }
        /// <summary>
        /// Useful for planning and informing the customer.
        /// </summary>
        public DateTime? ExpectedCompletionDate { get; set; }
        public string? Notes { get; set; }

        public int FabricId { get; set; }

        /// <summary>
        /// If different fabric can have different prices based on the Fabric or 
        /// customizations applied, a CostAtTimeOfOrder field in the OrderGarment table is useful. 
        /// This allows for flexibility in pricing models where Fabric might have additional costs.
        /// if Fabric.CostPerMeter changes later, this preserves order's original cost.
        /// </summary>
        /// 
        public decimal? FabricCostAtTimeOfOrder { get; set; }
        /// <summary>
        /// How many meters (or yards) of the fabric were used in this specific order.
        /// </summary>
        public float? FabricQuantityUsed { get; set; }










        [ForeignKey(nameof(FabricId))]
        public Fabric? Fabric { get; set; }


        [ForeignKey(nameof(OrderId))]
        public Order? Order { get; set; }
        [ForeignKey(nameof(GarmentId))]
        public Garment? Garment { get; set; }

        public List<OrderGarmentEmbellishment> OrderGarmentEmbellishments { get; set; }



        ///// <summary>
        ///// Date fabric was cut for this order — useful for production tracking.
        ///// </summary>
        //public DateTime? CutDate { get; set; }

        ///// <summary>
        ///// Useful if garments are size-based (e.g., "M", "L", "XL") instead of measurement-driven.
        ///// </summary>
        //public string? Size { get; set; }

        ///// <summary>
        ///// Name or ID of the tailor responsible for producing this garment. Helps with tracking and accountability.
        ///// </summary>
        //public int? AssignedTailor { get; set; }
        ///// <summary>
        ///// Any free-form customizations like "Add gold buttons", "V-shaped neckline", etc.
        ///// </summary>
        //public string? CustomizationDetails { get; set; }

    }

}

//🧥 Example Use Case:

//An order for a custom blazer might look like:

//    Quantity: 1

//    Size: "L"

//    AssignedTailor: "Tailor#12"

//    CustomizationDetails: "Add two inside pockets"

//    ProductionStatus: "Stitching"

//    CutDate: 2025 - 07 - 14

//    ExpectedCompletionDate: 2025 - 07 - 20

