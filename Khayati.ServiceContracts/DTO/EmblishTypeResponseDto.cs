using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.ServiceContracts.DTO
{
    public class EmblishTypeResponseDto
    {
        public int EmblishTypeId { get; set; }
        public string EmblishTypeName { get; set; }

        public string EmblishTypeDiscription { get; set; }
    }

    public static class EmblishTypeExtention
    {
        public static EmblishTypeResponseDto ToEmblishTypeResponseDto(this EmblishType EmblishType)
        {
            return new EmblishTypeResponseDto
            {
                EmblishTypeId = EmblishType.EmblishTypeId,
                EmblishTypeName = EmblishType.EmblishTypeName,
                EmblishTypeDiscription = EmblishType.EmblishTypeDiscription,
            };
        }
    }
}
