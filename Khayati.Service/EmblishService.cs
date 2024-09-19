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
    public class EmbellishmentService : IEmbellishmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmbellishmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmbellishmentAddDto> AddEmbellishment(EmbellishmentAddDto EmbellishmentAddDto)
        {
            if (EmbellishmentAddDto == null)
            {
                return null;
            }
            Embellishment Embellishment = EmbellishmentAddDto.ToEmbellishment();
            await _unitOfWork.EmbellishmentRepository.Add(Embellishment);
            await _unitOfWork.SaveChanges(CancellationToken.None);
            return EmbellishmentAddDto;

        }

        public async Task<EmbellishmentResponseDto> DeleteEmbellishment(int? EmbellishmentId)
        {
            if (!EmbellishmentId.HasValue)
            {
                return null;
            }
            Embellishment Embellishment = await _unitOfWork.EmbellishmentRepository.GetById((int)EmbellishmentId);
            if (Embellishment == null)
            {
                return null;
            }
            await _unitOfWork.EmbellishmentRepository.Remove(Embellishment);
            await _unitOfWork.SaveChanges(default);

            return Embellishment.ToEmbellishmentResponseDto();

        }


        public async Task<EmbellishmentResponseDto> GetEmbellishmentById(int? EmbellishmentId)
        {
            if (EmbellishmentId == null || EmbellishmentId == 0)
            {
                return null;
            }
            Embellishment Embellishment = await _unitOfWork.EmbellishmentRepository
                .GetFirstOrDefault(x => x.EmbellishmentId == EmbellishmentId);

            EmbellishmentResponseDto EmbellishmentResponseDto = Embellishment.ToEmbellishmentResponseDto();
            return EmbellishmentResponseDto;

        }

        public async Task<IEnumerable<EmbellishmentResponseDto>> GetEmbellishmentList()
        {
            IEnumerable<Embellishment> Embellishments = await _unitOfWork.EmbellishmentRepository.GetAll();
            if (Embellishments is null)
            {
                return null;
            }

            IEnumerable<EmbellishmentResponseDto> EmbellishmentResponseDtos = Embellishments
                .Select(temp => temp.ToEmbellishmentResponseDto());

            return EmbellishmentResponseDtos;

        }

    }
}
