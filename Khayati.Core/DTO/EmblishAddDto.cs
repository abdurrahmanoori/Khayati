﻿using Entities;

namespace Khayati.ServiceContracts.DTO
{
    public class EmbellishmentAddDto
    {

        public int EmbellishmentTypeId { get; set; }
        public string EmbellishmentName { get; set; }

        public string EmbellishmentDescription { get; set; }


        public Embellishment ToEmbellishment()
        {
            return new Embellishment
            {
                EmbellishmentName = EmbellishmentName,
                EmbellishmentDiscription = EmbellishmentDescription,
                EmbellishmentTypeId = EmbellishmentTypeId
            };
        }

    }
}
