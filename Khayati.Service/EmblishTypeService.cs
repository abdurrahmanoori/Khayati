using Entities;
using Khayati.ServiceContracts;
using Khayati.ServiceContracts.DTO;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class EmbellishmentTypeService : IEmbellishmentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmbellishmentTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmbellishmentTypeAddDto> AddEmbellishmentType(EmbellishmentTypeAddDto EmbellishmentTypeAddDto)
        {
            if (EmbellishmentTypeAddDto == null)
            {
                return null;
            }
            EmbellishmentType EmbellishmentType = EmbellishmentTypeAddDto.ToEmbellishmentType();
            await _unitOfWork.EmbellishmentTypeRepository.Add(EmbellishmentType);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return EmbellishmentTypeAddDto;

        }

        public async Task<EmbellishmentTypeResponseDto> DeleteEmbellishmentType(int? EmbellishmentTypeId)
        {
            if (!EmbellishmentTypeId.HasValue)
            {
                return null;
            }
            EmbellishmentType EmbellishmentType = await _unitOfWork.EmbellishmentTypeRepository.GetById((int)EmbellishmentTypeId);
            if (EmbellishmentType == null)
            {
                return null;
            }
            await _unitOfWork.EmbellishmentTypeRepository.Remove(EmbellishmentType);
            await _unitOfWork.SaveChanges(default);

            return EmbellishmentType.ToEmbellishmentTypeResponseDto();

        }


        public async Task<EmbellishmentTypeResponseDto> GetEmbellishmentTypeById(int? EmbellishmentTypeId)
        {
            if (EmbellishmentTypeId == null || EmbellishmentTypeId == 0)
            {
                return null;
            }
            EmbellishmentType EmbellishmentType = await _unitOfWork.EmbellishmentTypeRepository
                .GetFirstOrDefault(x => x.EmbellishmentTypeId == EmbellishmentTypeId);

            EmbellishmentTypeResponseDto EmbellishmentTypeResponseDto = EmbellishmentType.ToEmbellishmentTypeResponseDto();
            return EmbellishmentTypeResponseDto;

        }

        public async Task<IEnumerable<EmbellishmentTypeResponseDto>> GetEmbellishmentTypeList()
        {
            IEnumerable<EmbellishmentType> EmbellishmentTypes = await _unitOfWork.EmbellishmentTypeRepository.GetAll();
            if (EmbellishmentTypes is null)
            {
                return null;
            }

            IEnumerable<EmbellishmentTypeResponseDto> EmbellishmentTypeResponseDtos = EmbellishmentTypes
                .Select(temp => temp.ToEmbellishmentTypeResponseDto());

            return EmbellishmentTypeResponseDtos;

        }

    }
}