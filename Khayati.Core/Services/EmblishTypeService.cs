﻿using AutoMapper;
using Entities;
using Khayati.Core.DTO;
using Khayati.Core.DTO.EmbellishmentType;
using Khayati.ServiceContracts;
using RepositoryContracts.Base;

namespace Khayati.Service
{
    public class EmbellishmentTypeService : IEmbellishmentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmbellishmentTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmbellishmentTypeAddDto> AddEmbellishmentType(EmbellishmentTypeAddDto embellishmentTypeAddDto)
        {
            if (embellishmentTypeAddDto == null)
            {
                return null;
            }
            EmbellishmentType EmbellishmentType = embellishmentTypeAddDto.ToEmbellishmentType();

            await _unitOfWork.EmbellishmentTypeRepository.Add(EmbellishmentType);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return embellishmentTypeAddDto;

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

        public async Task<IEnumerable<EmbellishmentTypeResponseDto>>
            GetEmbellishmentTypeList()
        {
            IEnumerable<EmbellishmentType> EmbellishmentTypes =
                await _unitOfWork.EmbellishmentTypeRepository
                .GetAll();

            if (EmbellishmentTypes is null)
            {
                return null;
            }

            IEnumerable<EmbellishmentTypeResponseDto> EmbellishmentTypeResponseDtos = EmbellishmentTypes
                .Select(temp => temp.ToEmbellishmentTypeResponseDto());

            return EmbellishmentTypeResponseDtos;

        }

        public async Task<EmbellishmentTypeResponseDto> UpdateEmbellishmentType(EmbellishmentTypeResponseDto embellishmentTypeResponseDto)
        {
            if(embellishmentTypeResponseDto is null)
            {
                return null;
            }
            var embellishmentType = _mapper.Map<EmbellishmentType>(embellishmentTypeResponseDto);

             await _unitOfWork.EmbellishmentTypeRepository.Update(embellishmentType);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return embellishmentTypeResponseDto;
        }
    }
}