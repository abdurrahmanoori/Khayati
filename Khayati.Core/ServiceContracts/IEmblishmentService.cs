﻿using Khayati.Core.Common.Response;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Embellishments;

namespace Khayati.ServiceContracts
{
    public interface IEmbellishmentService
    {
        public Task<EmbellishmentAddDto> AddEmbellishment(EmbellishmentAddDto addEmbellishmentDto);
        public Task<EmbellishmentResponseDto> GetEmbellishmentById(int? EmbellishmentId);
        public Task<EmbellishmentDetailDto> GetEmbellishmentDetails(int? EmbellishmentId);

        public Task<Result<IEnumerable<EmellishmentResponseDetailsDto>>> GetEmbellishmentList();

        public Task<EmbellishmentResponseDto> DeleteEmbellishment(int? EmbellishmentId);
        // public Task<EmbellishmentResponseDto> UpdateEmbellishment(int? EmbellishmentId);

    }
}
