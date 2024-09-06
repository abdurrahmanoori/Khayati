using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int DesignID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedCompletionDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }

        public Customer Customer { get; set; }
        public Design Design { get; set; }
    }
}
