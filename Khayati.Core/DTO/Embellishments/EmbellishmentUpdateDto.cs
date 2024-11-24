namespace Khayati.Core.DTO.Embellishments
{
    public class EmbellishmentUpdateDto
    {     
            public int EmbellishmentId { get; set; }

            public string Name { get; set; }
            public string? Description { get; set; }
            public int? Cost { get; set; }
            public int? EmbellishmentTypeId { get; set; }

            public bool? IsAcitve { get; set; }


    }
}
