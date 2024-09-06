using Entities;
using Khayati.ServiceContracts.DTO;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Service
{
    public class EmblishService : IEmblishService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmblishService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmblishAddDto> AddEmblish(EmblishAddDto EmblishAddDto)
        {
            if (EmblishAddDto == null)
            {
                return null;
            }
            Emblish Emblish = EmblishAddDto.ToEmblish();
            await _unitOfWork.EmblishRepository.Add(Emblish);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return EmblishAddDto;

        }

        public async Task<EmblishResponseDto> DeleteEmblish(int? EmblishId)
        {
            if (!EmblishId.HasValue)
            {
                return null;
            }
            Emblish Emblish = await _unitOfWork.EmblishRepository.GetById((int)EmblishId);
            if (Emblish == null)
            {
                return null;
            }
            await _unitOfWork.EmblishRepository.Remove(Emblish);
            await _unitOfWork.SaveChanges(default);

            return Emblish.ToEmblishResponseDto();

        }


        public async Task<EmblishResponseDto> GetEmblishById(int? EmblishId)
        {
            if (EmblishId == null || EmblishId == 0)
            {
                return null;
            }
            Emblish Emblish = await _unitOfWork.EmblishRepository
                .GetFirstOrDefault(x => x.EmblishId == EmblishId);

            EmblishResponseDto EmblishResponseDto = Emblish.ToEmblishResponseDto();
            return EmblishResponseDto;

        }

        public async Task<IEnumerable<EmblishResponseDto>> GetEmblishList()
        {
            IEnumerable<Emblish> Emblishs = await _unitOfWork.EmblishRepository.GetAll();
            if (Emblishs is null)
            {
                return null;
            }

            IEnumerable<EmblishResponseDto> EmblishResponseDtos = Emblishs
                .Select(temp => temp.ToEmblishResponseDto());

            return EmblishResponseDtos;

        }

    }
}
