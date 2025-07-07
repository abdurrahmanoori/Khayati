using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.DTO.Fabric
{
    public class FabricAddDto
    {
        public string FabricType { get; set; }

        public string Color { get; set; }
        public float RequiredMeters { get; set; }

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

        /// <summary>
        /// The cost of the fabric per meter.
        /// </summary>
        public decimal CostPerMeter { get; set; }

    }
}
