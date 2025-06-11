using Khayati.Core.DTO;
using Khayati.Core.DTO.Embellishment;
using Khayati.Core.DTO.Embellishment.Validatores;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmbellishmentsController : BaseApiController
    {
        private readonly IEmbellishmentService _embellishmentService;

        public EmbellishmentsController(IEmbellishmentService embellishmentService)
        {
            _embellishmentService = embellishmentService;
        }

        [HttpPost]
        public async Task<ActionResult<EmbellishmentAddDto>> Create([FromBody] EmbellishmentAddDto dto)
        {
            return HandleResultResponse(await _embellishmentService.AddEmbellishment(dto));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmellishmentResponseDetailsDto>>> GetAll()
        {
            return HandleResultResponse(await _embellishmentService.GetEmbellishmentList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmbellishmentResponseDto>> GetById(int id)
        {
            return HandleResultResponse(await _embellishmentService.GetEmbellishmentById(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Update(int id, [FromBody] EmbellishmentResponseDto dto)
        {
            return HandleResultResponse(await _embellishmentService.UpdateEmbellishment(id, dto));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return HandleResultResponse(await _embellishmentService.DeleteEmbellishment(id));
        }
    }

}