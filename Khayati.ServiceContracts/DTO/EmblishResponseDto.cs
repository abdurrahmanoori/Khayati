using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.ServiceContracts.DTO
{
    public class EmblishResponseDto
    {
        public int EmblishId { get; set; }
        public string EmblishName { get; set; }

        public string EmblishDiscription { get; set; }
    }

    public static class EmblishExtention
    {
        public static EmblishResponseDto ToEmblishResponseDto(this Emblish Emblishr)
        {
            return new EmblishResponseDto
            {
                EmblishId = Emblishr.EmblishId,
                EmblishName = Emblishr.EmblishName,
                EmblishDiscription = Emblishr.EmblishDiscription,
            };
        }
    }
}
