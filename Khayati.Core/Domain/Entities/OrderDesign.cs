﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace Entities
{
    /// <summary>
    /// This class connects Order, Customer, and Embellishment
    /// </summary>
    public class OrderDesign   
    {
        [Key]
        public int DesignId { get; set; }
        public int CustomerId { get; set; }

        public int OrderId { get; set; }
        /// <summary>
        /// You could add a foreign key to MeasurementId if each design
        /// is based on specific customer measurements.
        /// </summary>
        public int MeasurementId { get; set; }
        public int? EmbellishmentId { get; set; }
                
        public string? ImageUrl { get; set; }
        public string? Notes { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public virtual Customer? Customer { get; set; }
        //public Measurement Measurement { get; set; }
        [ForeignKey(nameof(EmbellishmentId))]
        public virtual Embellishment? Embellishment { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order? Order { get; set; }
    }

}
