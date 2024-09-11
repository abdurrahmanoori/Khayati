using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Orders
    {
        [Key]
        public int OrdersId { get; set; }
        public int CustomerId { get; set; }
        //public int DesignId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedCompletionDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }
        [ForeignKey(nameof(CustomerId))]    
        public Customer Customer { get; set; }
        //public Design Design { get; set; }
    }
}
