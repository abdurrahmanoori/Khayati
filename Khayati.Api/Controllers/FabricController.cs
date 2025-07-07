using Khayati.Core.DTO.Fabric;
using Khayati.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricController:BaseApiController
    {
        private readonly IFabricService _fabricService;

        public FabricController(IFabricService fabricService)
        {
            _fabricService = fabricService;
        }

        [HttpPost]
        public async Task<ActionResult<FabricResponseDto>> Create(FabricAddDto dto) =>
            HandleResultResponse(await _fabricService.AddFabric(dto));

        [HttpGet]
        public async Task<ActionResult<List<FabricResponseDto>>> GetAll() =>
            HandleResultResponse(await _fabricService.GetFabricList());

        [HttpGet("{id}")]
        public async Task<ActionResult<FabricResponseDto>> GetById(int id) =>
            HandleResultResponse(await _fabricService.GetFabricById(id));

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, FabricAddDto dto) =>
            HandleResultResponse(await _fabricService.UpdateFabric(id, dto));

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id) =>
            HandleResultResponse(await _fabricService.DeleteFabric(id));
    }


}
