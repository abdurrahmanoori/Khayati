using Khayati.Core.DTO;
using Khayati.Core.DTO.Garments;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarmentController : BaseApiController
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IGarmentService _garmentService;

        public GarmentController(IGarmentService grmentService)
        {
            _garmentService = grmentService;
        }

        [HttpPost]
        public async Task<ActionResult<GarmentDto>> Create(GarmentAddDto dto) =>
         HandleResultResponse(await _garmentService.AddGarment(dto));

        [HttpGet]
        public async Task<ActionResult<List<GarmentDto>>> GetAll( ) =>
            HandleResultResponse(await _garmentService.GetGarmentList());

        [HttpGet("{id}")]
        public async Task<ActionResult<GarmentDto>> GetById(int id) =>
            HandleResultResponse(await _garmentService.GetGarmentById(id));

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, GarmentDto dto) =>    
            HandleResultResponse(await _garmentService.UpdateGarment(id, dto));

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id) =>
            HandleResultResponse(await _garmentService.DeleteGarment(id));
    }
}
