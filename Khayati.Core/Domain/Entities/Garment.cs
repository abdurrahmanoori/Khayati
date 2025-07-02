using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.Domain.Entities
{
    public class Garment
    {
        public int GarmentId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Cost { get; set; }
    }
}
