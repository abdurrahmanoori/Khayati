﻿using Khayati.Core.Common;
using Khayati.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    /// <summary>
    /// Represents the Measurements entity, responsible for storing and handling customer measurement details.
    /// </summary>
    public class Measurement : AuditableEntity
    {
        /// <summary>
        /// Unique identifier for the measurement.
        /// </summary>
        public int MeasurementId { get; set; }

        public int? GarmentId { get; set; }

        /// <summary>
        /// Foreign key reference to the customer who owns the measurement.
        /// </summary>
        public int CustomerId { get; set; }


        /// <summary>
        /// The date when the measurement was taken.
        /// </summary>
       // public DateTime DateTaken { get; set; }

        /// <summary>
        /// Customer's height (قد) measurement.
        /// </summary>

        public double Height { get; set; }
        /// <summary>
        /// Customer's arm length (آستین) measurement.
        /// </summary>
        public double ArmLength { get; set; }
        /// <summary>
        /// Customer's Sleeve (دهن آستین) measurement.
        /// </summary>
        public double Sleeve { get; set; }

        /// <summary>
        /// Customer's shoulder width (شانه) measurement.
        /// </summary>
        public double ShoulderWidth { get; set; }

        /// <summary>
        /// Customer's Neck (یخن) measurement.
        /// </summary>
        public double Neck { get; set; }


        /// <summary>
        /// Customer's chest(سینه/بغل ) measurement.
        /// </summary>
        public double Chest { get; set; }

        /// <summary>
        /// Customer's waist (دامن) measurement.
        /// </summary>
        public double Waist { get; set; }


        /// <summary>
        /// Customer's trousers (تنبان) measurement.
        /// </summary>
        public double trousers { get; set; }

        /// <summary>
        /// Customer's Leg (پاچه) measurement.
        /// </summary>
        public double Leg { get; set; }

        [Required(AllowEmptyStrings = true)]
        public int? FabricId { get; set; }


        public string? Description { get; set; }
        /// <summary>
        /// Indicates the date when this measurement was created. Useful for tracking the most recent measurement of a customer.
        /// </summary>
       // public DateTime DateCreated { get; set; }

        /// <summary>
        /// Navigation property for the related Customer entity.
        /// </summary>
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(FabricId))]
        public virtual Fabric Fabric { get; set; }

        [ForeignKey(nameof(GarmentId))]
        public Garment Garment { get; set; }
    }
}
