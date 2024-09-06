using Khayati.ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.ServiceContracts
{
    public interface IEmblishService
    {
        public Task<EmblishAddDto> AddEmblish(EmblishAddDto addEmblishDto);
        public Task<EmblishResponseDto> GetEmblishById(int? EmblishId);

        public Task<IEnumerable<EmblishResponseDto>> GetEmblishList();

        public Task<EmblishResponseDto> DeleteEmblish(int? EmblishId);
        // public Task<EmblishResponseDto> UpdateEmblish(int? EmblishId);

    }
}
