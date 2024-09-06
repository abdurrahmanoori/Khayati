using Entities;

namespace Khayati.ServiceContracts.DTO
{
    public class EmblishAddDto
    {

        public int EmblishTypeId { get; set; }
        public string EmblishName { get; set; }

        public string EmblishDescription { get; set; }


        public Emblish ToEmblish()
        {
            return new Emblish
            {
                EmblishName = EmblishName,
                EmblishDiscription = EmblishDescription,
                EmblishTypeId = EmblishTypeId
            };
        }

    }
}
