using Entities;
using Khayati.ServiceContracts;
using Khayati.ServiceContracts.DTO;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class EmblishTypeService : IEmblishTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmblishTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmblishTypeAddDto> AddEmblishType(EmblishTypeAddDto EmblishTypeAddDto)
        {
            if (EmblishTypeAddDto == null)
            {
                return null;
            }
            EmblishType EmblishType = EmblishTypeAddDto.ToEmblishType();
            await _unitOfWork.EmblishTypeRepository.Add(EmblishType);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return EmblishTypeAddDto;

        }

        public async Task<EmblishTypeResponseDto> DeleteEmblishType(int? EmblishTypeId)
        {
            if (!EmblishTypeId.HasValue)
            {
                return null;
            }
            EmblishType EmblishType = await _unitOfWork.EmblishTypeRepository.GetById((int)EmblishTypeId);
            if (EmblishType == null)
            {
                return null;
            }
            await _unitOfWork.EmblishTypeRepository.Remove(EmblishType);
            await _unitOfWork.SaveChanges(default);

            return EmblishType.ToEmblishTypeResponseDto();

        }


        public async Task<EmblishTypeResponseDto> GetEmblishTypeById(int? EmblishTypeId)
        {
            if (EmblishTypeId == null || EmblishTypeId == 0)
            {
                return null;
            }
            EmblishType EmblishType = await _unitOfWork.EmblishTypeRepository
                .GetFirstOrDefault(x => x.EmblishTypeId == EmblishTypeId);

            EmblishTypeResponseDto EmblishTypeResponseDto = EmblishType.ToEmblishTypeResponseDto();
            return EmblishTypeResponseDto;

        }

        public async Task<IEnumerable<EmblishTypeResponseDto>> GetEmblishTypeList()
        {
            IEnumerable<EmblishType> EmblishTypes = await _unitOfWork.EmblishTypeRepository.GetAll();
            if (EmblishTypes is null)
            {
                return null;
            }

            IEnumerable<EmblishTypeResponseDto> EmblishTypeResponseDtos = EmblishTypes
                .Select(temp => temp.ToEmblishTypeResponseDto());

            return EmblishTypeResponseDtos;

        }

    }
}