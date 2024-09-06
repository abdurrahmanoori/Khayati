using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Design
    {
        public int DesignID { get; set; }
        public int CustomerID { get; set; }
        public int MeasurementID { get; set; }
        public string DesignName { get; set; }
        public string DesignDescription { get; set; }
        public string ImageUrl { get; set; }
        public string Notes { get; set; }

        public Customer Customer { get; set; }
        public Measurement Measurement { get; set; }
    }

}
