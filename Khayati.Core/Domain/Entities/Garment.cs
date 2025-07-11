﻿using Entities;

namespace Khayati.Core.Domain.Entities
{
    public class Garment
    {
        public int GarmentId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Cost { get; set; }

        public ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();
        public virtual ICollection<GarmentField> GarmentFields { get; set; } = new List<GarmentField>();

    }
}
