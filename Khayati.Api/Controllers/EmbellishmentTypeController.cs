using Entities;
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

        [HttpPost]
        public async Task<ActionResult<EmbellishmentTypeAddDto>> Create(EmbellishmentTypeAddDto addEmbellishmentTypeDto)
        {
            return HandleResultResponse(await _embellishmentTypeService.AddEmbellishmentType(addEmbellishmentTypeDto));

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmbellishmentTypeResponseDto>>> GetEmbellishmentTypeList()
        {
            return HandleResultResponse(await _embellishmentTypeService.GetEmbellishmentTypeList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmbellishmentTypeResponseDto>> GitById(int id)
        {
            return HandleResultResponse(await _embellishmentTypeService.GetEmbellishmentTypeById(id));

        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteEmbellishmentType(int embellishmentTypeId)
        {
          return  HandleResultResponse(await _embellishmentTypeService.DeleteEmbellishmentType(embellishmentTypeId));

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Edit(int id,EmbellishmentTypeResponseDto embellishmentType)
        {
            return HandleResultResponse(await _embellishmentTypeService.UpdateEmbellishmentType(id,embellishmentType));


        }





    }
}
