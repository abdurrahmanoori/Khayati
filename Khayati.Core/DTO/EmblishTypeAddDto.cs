using Entities;
using System.ComponentModel.DataAnnotations;

namespace Khayati.Core.DTO
{
    public class EmbellishmentTypeAddDto
    {
        [Required(ErrorMessage ="Name is required from annotation")]
        public string Name { get; set; }

        public string Description { get; set; }
        public short? SortOrder { get; set; }


        public Entities.EmbellishmentType ToEmbellishmentType()
        {
            return new Entities.EmbellishmentType
            {
                Name = Name,
                Description = Description
            };
        }

    }
}
