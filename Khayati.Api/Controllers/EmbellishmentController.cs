using Khayati.Core.DTO;
using Khayati.Core.DTO.Embellishment;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbellishmentController : BaseApiController
    {
        private readonly IEmbellishmentervice _Embellishmentervice;

        public EmbellishmentController(IEmbellishmentervice Embellishmentervice)
        {
            _Embellishmentervice = Embellishmentervice;
        }

        [HttpPost]
        public async Task<ActionResult<EmbellishmentAddDto>> 
            AddEmbellishment(EmbellishmentAddDto addEmbellishmentDto)
        {
            var result = await _Embellishmentervice
                .AddEmbellishment(addEmbellishmentDto);

            return HandleResultResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmellishmentResponseDetailsDto>>>
            GetEmbellishmentList( )
        {
            var results = await _Embellishmentervice
                .GetEmbellishmentList();

            return HandleResultResponse(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmbellishmentResponseDto>>
            GetEmbellishmentById(int id)
        {
            var embellishment = await _Embellishmentervice.GetEmbellishmentById(id);
            return HandleResultResponse(embellishment);
        }

        [HttpDelete("{embellishmentId}")]
        public async Task<ActionResult<EmbellishmentResponseDto>> 
            DeleteEmbellishment(int embellishmentId)
        {
            var embellishment = await _Embellishmentervice.DeleteEmbellishment(embellishmentId);
            return HandleResultResponse(embellishment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>
            UpdateEmbellishment(int id, EmbellishmentUpdateDto updateDto)
        {
            return HandleResult(await _Embellishmentervice.Update(id, updateDto));
        }
    }




    //[Route("api/[controller]")]
    //[ApiController]
    //public class EmbellishmentController : BaseApiController
    //{
    //    //private readonly IUnitOfWork _unitOfWork;
    //    private readonly IEmbellishmentervice _Embellishmentervice;

    //    public EmbellishmentController(IEmbellishmentervice Embellishmentervice)
    //    {
    //        _Embellishmentervice = Embellishmentervice;
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Create(EmbellishmentAddDto addEmbellishmentDto)
    //    {
    //        var result = await _Embellishmentervice.AddEmbellishment(addEmbellishmentDto);
    //        return Ok(result);

    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> GetEmbellishmentList( )
    //    {
    //        var results =
    //            await _Embellishmentervice
    //            .GetEmbellishmentList();

    //        return HandleResult(results);
    //    }

    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GitById(int id)
    //    {
    //        var Embellishment = await _Embellishmentervice.GetEmbellishmentById(id);

    //        return Ok(Embellishment);

    //    }

    //    [HttpDelete]
    //    public async Task<IActionResult> DeleteEmbellishment(int embellishmentId)
    //    {
    //        EmbellishmentResponseDto embellishment = await _Embellishmentervice.DeleteEmbellishment(embellishmentId);
    //        return Ok(embellishment);
    //    }

    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> Edit(int id, EmbellishmentUpdateDto updateDto)
    //    {

    //      return HandleResult(await _Embellishmentervice.Update(id,updateDto));

    //    }





    //}
}