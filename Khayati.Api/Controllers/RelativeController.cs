using Khayati.Core.DTO.Relative;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelativeController : BaseApiController
    {
        private readonly IRelativeService _relativeService;

        public RelativeController(IRelativeService relativeService)
        {
            _relativeService = relativeService;
        }

        [HttpPost]
        public async Task<ActionResult<RelativeAddDto>> 
            AddRelative(RelativeAddDto addRelativeDto)
        {
            var result = await _relativeService
                .AddRelative(addRelativeDto);

            return HandleResultResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelativeDto>>>
            GetRelativeList( )
        {
            var results = await _relativeService
                .GetRelativeList();

            return HandleResultResponse(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RelativeDto>>
            GetRelativeById(int id)
        {
            var relative = await _relativeService.GetRelativeById(id);
            return HandleResultResponse(relative);
        }

        [HttpDelete("{relativeId}")]
        public async Task<ActionResult<RelativeResponseDto>>
            DeleteRelative(int relativeId)
        {
            var Relative = await _relativeService.DeleteRelative(relativeId);
            return HandleResultResponse(Relative);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>
            UpdateRelative(int id, RelativeUpdateDto relativeDto)
        {
            return HandleResult(await _relativeService.UpdateRelative(id, relativeDto));
        }
    }




    //[Route("api/[controller]")]
    //[ApiController]
    //public class RelativeController : BaseApiController
    //{
    //    //private readonly IUnitOfWork _unitOfWork;
    //    private readonly IRelativeService _RelativeService;

    //    public RelativeController(IRelativeService RelativeService)
    //    {
    //        _RelativeService = RelativeService;
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Create(RelativeAddDto addRelativeDto)
    //    {
    //        var result = await _RelativeService.AddRelative(addRelativeDto);
    //        return Ok(result);

    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> GetRelativeList( )
    //    {
    //        var results =
    //            await _RelativeService
    //            .GetRelativeList();

    //        return HandleResult(results);
    //    }

    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GitById(int id)
    //    {
    //        var Relative = await _RelativeService.GetRelativeById(id);

    //        return Ok(Relative);

    //    }

    //    [HttpDelete]
    //    public async Task<IActionResult> DeleteRelative(int RelativeId)
    //    {
    //        RelativeResponseDto Relative = await _RelativeService.DeleteRelative(RelativeId);
    //        return Ok(Relative);
    //    }

    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> Edit(int id, RelativeUpdateDto updateDto)
    //    {

    //      return HandleResult(await _RelativeService.Update(id,updateDto));

    //    }





    //}
}