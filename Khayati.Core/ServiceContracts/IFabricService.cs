using Khayati.Core.Common.Response;
using Khayati.Core.DTO.Customers;
using Khayati.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Khayati.Core.DTO.Fabric;

namespace Khayati.Core.ServiceContracts
{
    public interface IFabricService
    {
        Task<Result<FabricResponseDto>> AddFabric(FabricAddDto dto);
        Task<Result<bool>> UpdateFabric(int id, FabricAddDto dto);
        Task<Result<FabricResponseDto>> GetFabricById(int id);
        Task<Result<List<FabricResponseDto>>> GetFabricList();
        Task<Result<bool>> DeleteFabric(int id);

    }
}
