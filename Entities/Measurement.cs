using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Measurement
    {

        public int MeasurementID { get; set; }
        public int CustomerID { get; set; }
        public DateTime DateTaken { get; set; }
        public double Height { get; set; }
        public double Chest { get; set; }
        public double Waist { get; set; }
        public double Hip { get; set; }
        public double ShoulderWidth { get; set; }
        public double ArmLength { get; set; }
        public double Inseam { get; set; }


        [ForeignKey(nameof(CustomerID))]
        public Customer Customer { get; set; }


    }
}
