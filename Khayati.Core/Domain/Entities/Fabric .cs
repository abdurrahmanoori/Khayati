namespace Khayati.Core.Domain.Entities
{
    public class Fabric
    {
        public int FabricId { get; set; }

        /// <summary>
        /// The type of the fabric (e.g., cotton, silk, polyester).
        /// </summary>
        public string FabricType { get; set; }

        public string Color { get; set; }

        /// <summary>
        /// The pattern on the fabric (e.g., striped, floral).
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// The thickness of the fabric in millimeters.
        /// </summary>
        public short Thickness { get; set; }

        /// <summary>
        /// The durability of the fabric, indicating its resilience.
        /// </summary>
        public string Durability { get; set; }

        ///// <summary>
        ///// The level of sharpness required for tools used with this fabric.
        ///// </summary>
        //public int SharpnessLevelRequired { get; set; }

        ///// <summary>
        ///// Indicates the fabric's fragility, assessing the likelihood of tearing.
        ///// </summary>
        //public string Fragility { get; set; }

        /// <summary>
        /// The cost of the fabric per meter.
        /// </summary>
        public decimal CostPerMeter { get; set; }

        //public virtual ICollection<Customer> Customers { get; set; }
    }
}
