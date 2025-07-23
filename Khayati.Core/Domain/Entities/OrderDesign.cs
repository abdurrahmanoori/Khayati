using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.Domain.Entities
{
    public class OrderDesign
    {
               [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FabricId { get; set; }
        public int GarmentId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order order { get; set; }

        [ForeignKey(nameof(GarmentId))]
        public virtual Garment garment { get; set; }

        [ForeignKey(nameof(FabricId))]
        public virtual Fabric fabric { get; set; }
        public ICollection<OrderEmbellishment> Embellishments { get; set; }
     
     
    }
}
