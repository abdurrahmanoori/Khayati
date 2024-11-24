using Khayati.Core.DTO.Embellishments;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbellishmentController : BaseApiController
    {
        private readonly IEmbellishmentService _embellishmentService;

        public EmbellishmentController(IEmbellishmentService embellishmentService)
        {
            _embellishmentService = embellishmentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmbellishment(EmbellishmentAddDto addEmbellishmentDto)
        {
            var result = await _embellishmentService.AddEmbellishment(addEmbellishmentDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmbellishmentList( )
        {
            var results = await _embellishmentService.GetEmbellishmentList();
            return HandleResult(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmbellishmentById(int id)
        {
            var embellishment = await _embellishmentService.GetEmbellishmentById(id);
            return Ok(embellishment);
        }

        [HttpDelete("{embellishmentId}")]
        public async Task<IActionResult> DeleteEmbellishment(int embellishmentId)
        {
            var embellishment = await _embellishmentService.DeleteEmbellishment(embellishmentId);
            return Ok(embellishment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmbellishment(int id, EmbellishmentUpdateDto updateDto)
        {
            return HandleResult(await _embellishmentService.Update(id, updateDto));
        }
    }




    //[Route("api/[controller]")]
    //[ApiController]
    //public class EmbellishmentController : BaseApiController
    //{
    //    //private readonly IUnitOfWork _unitOfWork;
    //    private readonly IEmbellishmentService _embellishmentService;

    //    public EmbellishmentController(IEmbellishmentService embellishmentService)
    //    {
    //        _embellishmentService = embellishmentService;
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Create(EmbellishmentAddDto addEmbellishmentDto)
    //    {
    //        var result = await _embellishmentService.AddEmbellishment(addEmbellishmentDto);
    //        return Ok(result);

    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> GetEmbellishmentList( )
    //    {
    //        var results =
    //            await _embellishmentService
    //            .GetEmbellishmentList();

    //        return HandleResult(results);
    //    }

    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GitById(int id)
    //    {
    //        var Embellishment = await _embellishmentService.GetEmbellishmentById(id);

    //        return Ok(Embellishment);

    //    }

    //    [HttpDelete]
    //    public async Task<IActionResult> DeleteEmbellishment(int embellishmentId)
    //    {
    //        EmbellishmentResponseDto embellishment = await _embellishmentService.DeleteEmbellishment(embellishmentId);
    //        return Ok(embellishment);
    //    }

    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> Edit(int id, EmbellishmentUpdateDto updateDto)
    //    {

    //      return HandleResult(await _embellishmentService.Update(id,updateDto));

    //    }





    //}
}