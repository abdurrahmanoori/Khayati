using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public  class Embellish
    {
        public int EmbellishId { get; set; }

        public string EmbelishName { get; set; }

        public int? EmbellishTypeId { get; set; }


        public virtual EmbellishType? EmbellishType { get; set; }

        //public virtual ICollection<OrderEmbellish>? OrderEmbellishes { get; set; }
    }
}
