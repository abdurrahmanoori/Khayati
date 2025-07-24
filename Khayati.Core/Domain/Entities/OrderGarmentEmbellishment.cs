using Khayati.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class OrderGarmentEmbellishment
    {
        [Key]
        public int Id { get; set; }
        public int EmbellishmentId { get; set; }
        /// <summary>
        /// Optional free-form notes from the designer or client (e.g., "Use gold thread"). Provides clarity for custom jobs.
        /// </summary>
        public string? CustomInstructions { get; set; }
        /// <summary>
        /// If different designs can have different prices based on the Embellishment or 
        /// customizations applied, a CostAtTimeOfOrder field in the OrderDesigns table is useful. 
        /// This allows for flexibility in pricing models where designs might have additional costs.
        /// </summary>
        /// 
        public decimal? CostAtTimeOfOrder { get; set; }
        /// <summary>
        /// Name or ID of the worker/vendor who applied the embellishment. Useful for tracking accountability or quality control.
        /// </summary>
        public int? AppliedBy { get; set; }
      
        [ForeignKey(nameof(EmbellishmentId))]
        public Embellishment? Embellishment { get; set; }



        ///// <summary>
        ///// To capture how many instances of the embellishment are applied (e.g., 4 patches). Useful for costing and production planning.
        ///// </summary>

        //public int? Quantity { get; set; }
        ///// <summary>
        ///// Describes where the embellishment is applied (e.g., "left sleeve", "collar"). Helps production staff understand the placement.
        ///// </summary>
        //public string? ApplicationLocation { get; set; }
        ///// <summary>
        ///// When the embellishment was applied. Helps with timeline analysis, delays, and order traceability.
        ///// </summary>
        //public DateTime AppliedDate { get; set; }


    }

}
