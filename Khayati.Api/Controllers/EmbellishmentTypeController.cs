using Khayati.Core.DTO.EmbellishmentType;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmbellishmentTypeController : BaseApiController
    {
        private readonly IEmbellishmentTypeService _embellishmentTypeService;

        public EmbellishmentTypeController(IEmbellishmentTypeService embellishmentTypeService)
        {
            _embellishmentTypeService = embellishmentTypeService;
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<EmbellishmentTypeAddDto>> Create([FromBody] EmbellishmentTypeAddDto dto)
        {
            return HandleResultResponse(await _embellishmentTypeService.AddEmbellishmentType(dto));

        }

        [HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EmbellishmentTypeResponseDto>>> GetEmbellishmentTypeList() =>
             HandleResultResponse(await _embellishmentTypeService.GetEmbellishmentTypeList());


        [HttpGet("{id}")]
        public async Task<ActionResult<EmbellishmentTypeResponseDto>> GetById(int id)
        {
            return HandleResultResponse(await _embellishmentTypeService.GetEmbellishmentTypeById(id));

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEmbellishmentType(int id)
        {
            return HandleResultResponse(await _embellishmentTypeService.DeleteEmbellishmentType(id));

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Edit(int id, EmbellishmentTypeResponseDto embellishmentType)
        {
            return HandleResultResponse(await _embellishmentTypeService.UpdateEmbellishmentType(id, embellishmentType));


        }





    }
}
