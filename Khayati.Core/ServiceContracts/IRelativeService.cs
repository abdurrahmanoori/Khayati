﻿using Khayati.Core.Common.Response;
using Khayati.Core.DTO.Relative;

namespace Khayati.ServiceContracts
{
    public interface IRelativeService
    {
        public Task<Result< RelativeAddDto>> AddRelative(RelativeAddDto addRelativeDto);
        public Task<Result< RelativeResponseDto>> GetRelativeById(int? RelativeId);

        public Task<Result<IEnumerable<RelativeDto>>> GetRelativeList();

        public Task<Result<RelativeResponseDto>> DeleteRelative(int RelativeId);

    }
}
