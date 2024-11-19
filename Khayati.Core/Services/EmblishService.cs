using Entities;
using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Embellishments;
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

        public async Task<EmbellishmentResponseDto>
            DeleteEmbellishment(int? embellishmentId)
        {
            if (!embellishmentId.HasValue)
            {
                return null;
            }
            Embellishment embellishment = await _unitOfWork.EmbellishmentRepository.GetById((int)embellishmentId);
            if (embellishment == null)
            {
                return null;
            }
            await _unitOfWork.EmbellishmentRepository.Remove(embellishment);
            await _unitOfWork.SaveChanges(default);

            return embellishment.ToEmbellishmentResponseDto();

        }


        public async Task<EmbellishmentResponseDto>
            GetEmbellishmentById(int? EmbellishmentId)
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

        public async Task<EmbellishmentDetailDto>
            GetEmbellishmentDetails(int? EmbellishmentId)
        {
            var query = (
                from e in await _unitOfWork.EmbellishmentRepository.GetAll()
                join et in await _unitOfWork.EmbellishmentTypeRepository.GetAll() on e.EmbellishmentTypeId equals et.EmbellishmentTypeId
                select new EmbellishmentDetailDto
                {
                    EmbellishmentId = e.EmbellishmentId,
                    Name = e.Name,
                    EmbellishmentTypeName = et.Name,
                    EmbellishmentTypeId = et.EmbellishmentTypeId,
                }
                ).FirstOrDefault();
            return query;
        }

        public async Task<Result<IEnumerable<EmellishmentResponseDetailsDto>>>
            GetEmbellishmentList( )
        {
            IEnumerable<EmellishmentResponseDetailsDto> embellishments =
              await _unitOfWork.EmbellishmentRepository
                .GetEmellishmentResponseDetailList();

            if (embellishments.Any() == false)
            {
                return Result<IEnumerable<EmellishmentResponseDetailsDto>>
                    .FailureResult(DeclareMessage.EmptyList.Code, DeclareMessage.EmptyList.Description);
            }

            return Result<IEnumerable<EmellishmentResponseDetailsDto>>.SuccessResult(embellishments);

        }

    }
}
