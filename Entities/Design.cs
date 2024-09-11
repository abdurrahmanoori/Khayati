using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Design
    {
        public int DesignId { get; set; }
        public int CustomerId { get; set; }
        public int MeasurementId { get; set; }
        public int EmblishId { get; set; }

        
        public string ImageUrl { get; set; }
        public string Notes { get; set; }

        public Customer Customer { get; set; }
        public Measurement Measurement { get; set; }
        public Measurement Emblish { get; set; }
    }

}
