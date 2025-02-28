﻿
using Khayati.Core.Common.Response;
using Khayati.Core.DTO.OrderDesign;

namespace Khayati.ServiceContracts
{
    public interface IOrderDesignService
    {
        public Task<Result<OrderDesignAddDto>> AddOrderDesign(OrderDesignAddDto addOrderDesignDto);
        //public Task<OrderDesignResponseDto> GetOrderDesignById(int? OrderDesignId);

        //public Task<IEnumerable<OrderDesignResponseDto>> GetOrderDesignList();

        //public Task<OrderDesignResponseDto> DeleteOrderDesign(int? OrderDesignId);

    }
}
