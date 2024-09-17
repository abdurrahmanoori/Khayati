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
    public class EmbellishmentmentService : IEmbellishmentmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmbellishmentmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmbellishmentmentAddDto> AddEmbellishmentment(EmbellishmentmentAddDto EmbellishmentmentAddDto)
        {
            if (EmbellishmentmentAddDto == null)
            {
                return null;
            }
            Embellishmentment Embellishmentment = EmbellishmentmentAddDto.ToEmbellishmentment();
            await _unitOfWork.EmbellishmentmentRepository.Add(Embellishmentment);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return EmbellishmentmentAddDto;

        }

        public async Task<EmbellishmentmentResponseDto> DeleteEmbellishmentment(int? EmbellishmentmentId)
        {
            if (!EmbellishmentmentId.HasValue)
            {
                return null;
            }
            Embellishmentment Embellishmentment = await _unitOfWork.EmbellishmentmentRepository.GetById((int)EmbellishmentmentId);
            if (Embellishmentment == null)
            {
                return null;
            }
            await _unitOfWork.EmbellishmentmentRepository.Remove(Embellishmentment);
            await _unitOfWork.SaveChanges(default);

            return Embellishmentment.ToEmbellishmentmentResponseDto();

        }


        public async Task<EmbellishmentmentResponseDto> GetEmbellishmentmentById(int? EmbellishmentmentId)
        {
            if (EmbellishmentmentId == null || EmbellishmentmentId == 0)
            {
                return null;
            }
            Embellishmentment Embellishmentment = await _unitOfWork.EmbellishmentmentRepository
                .GetFirstOrDefault(x => x.EmbellishmentmentId == EmbellishmentmentId);

            EmbellishmentmentResponseDto EmbellishmentmentResponseDto = Embellishmentment.ToEmbellishmentmentResponseDto();
            return EmbellishmentmentResponseDto;

        }

        public async Task<IEnumerable<EmbellishmentmentResponseDto>> GetEmbellishmentmentList()
        {
            IEnumerable<Embellishmentment> Embellishmentments = await _unitOfWork.EmbellishmentmentRepository.GetAll();
            if (Embellishmentments is null)
            {
                return null;
            }

            IEnumerable<EmbellishmentmentResponseDto> EmbellishmentmentResponseDtos = Embellishmentments
                .Select(temp => temp.ToEmbellishmentmentResponseDto());

            return EmbellishmentmentResponseDtos;

        }

    }
}
