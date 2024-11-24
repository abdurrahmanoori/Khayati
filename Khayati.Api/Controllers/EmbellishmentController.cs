using Khayati.Core.DTO;
using Khayati.Core.DTO.Embellishments;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbellishmentController : BaseApiController
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IEmbellishmentService _embellishmentService;

        public EmbellishmentController(IEmbellishmentService embellishmentService)
        {
            _embellishmentService = embellishmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmbellishmentAddDto addEmbellishmentDto)
        {
            var result = await _embellishmentService.AddEmbellishment(addEmbellishmentDto);
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetEmbellishmentList( )
        {
            var results =
                await _embellishmentService
                .GetEmbellishmentList();

            return HandleResult(results);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> GitById(int id)
        {
            var Embellishment = await _embellishmentService.GetEmbellishmentById(id);

            return Ok(Embellishment);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmbellishment(int embellishmentId)
        {
            EmbellishmentResponseDto embellishment = await _embellishmentService.DeleteEmbellishment(embellishmentId);
            return Ok(embellishment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, EmbellishmentUpdateDto updateDto)
        {

            await _embellishmentService.Update(id,updateDto);
            return Ok();

        }





    }
}