using Entities;
using Khayati.ServiceContracts;
using Khayati.ServiceContracts.DTO;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class EmbellishmentmentTypeService : IEmbellishmentmentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmbellishmentmentTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmbellishmentmentTypeAddDto> AddEmbellishmentmentType(EmbellishmentmentTypeAddDto EmbellishmentmentTypeAddDto)
        {
            if (EmbellishmentmentTypeAddDto == null)
            {
                return null;
            }
            EmbellishmentmentType EmbellishmentmentType = EmbellishmentmentTypeAddDto.ToEmbellishmentmentType();
            await _unitOfWork.EmbellishmentmentTypeRepository.Add(EmbellishmentmentType);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return EmbellishmentmentTypeAddDto;

        }

        public async Task<EmbellishmentmentTypeResponseDto> DeleteEmbellishmentmentType(int? EmbellishmentmentTypeId)
        {
            if (!EmbellishmentmentTypeId.HasValue)
            {
                return null;
            }
            EmbellishmentmentType EmbellishmentmentType = await _unitOfWork.EmbellishmentmentTypeRepository.GetById((int)EmbellishmentmentTypeId);
            if (EmbellishmentmentType == null)
            {
                return null;
            }
            await _unitOfWork.EmbellishmentmentTypeRepository.Remove(EmbellishmentmentType);
            await _unitOfWork.SaveChanges(default);

            return EmbellishmentmentType.ToEmbellishmentmentTypeResponseDto();

        }


        public async Task<EmbellishmentmentTypeResponseDto> GetEmbellishmentmentTypeById(int? EmbellishmentmentTypeId)
        {
            if (EmbellishmentmentTypeId == null || EmbellishmentmentTypeId == 0)
            {
                return null;
            }
            EmbellishmentmentType EmbellishmentmentType = await _unitOfWork.EmbellishmentmentTypeRepository
                .GetFirstOrDefault(x => x.EmbellishmentmentTypeId == EmbellishmentmentTypeId);

            EmbellishmentmentTypeResponseDto EmbellishmentmentTypeResponseDto = EmbellishmentmentType.ToEmbellishmentmentTypeResponseDto();
            return EmbellishmentmentTypeResponseDto;

        }

        public async Task<IEnumerable<EmbellishmentmentTypeResponseDto>> GetEmbellishmentmentTypeList()
        {
            IEnumerable<EmbellishmentmentType> EmbellishmentmentTypes = await _unitOfWork.EmbellishmentmentTypeRepository.GetAll();
            if (EmbellishmentmentTypes is null)
            {
                return null;
            }

            IEnumerable<EmbellishmentmentTypeResponseDto> EmbellishmentmentTypeResponseDtos = EmbellishmentmentTypes
                .Select(temp => temp.ToEmbellishmentmentTypeResponseDto());

            return EmbellishmentmentTypeResponseDtos;

        }

    }
}