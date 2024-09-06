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
        public static EmblishTypeResponseDto ToEmblishTypeResponseDto(this EmblishType EmblishTyper)
        {
            return new EmblishTypeResponseDto
            {
                EmblishTypeId = EmblishTyper.EmblishTypeId,
                EmblishTypeName = EmblishTyper.EmblishTypeName,
                EmblishTypeDiscription = EmblishTyper.EmblishTypeDiscription,
            };
        }
    }
}
