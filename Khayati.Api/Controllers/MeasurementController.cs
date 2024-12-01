using Khayati.Core.DTO.Measurement;
using Khayati.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace Khayati.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : BaseApiController
    {
        private readonly IMeasurementService _measurementService;

        public MeasurementController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        [HttpPost]
        public async Task<ActionResult<MeasurementAddDto>>
            AddMeasurement(MeasurementAddDto addMeasurementDto)
        {
            var result = await _measurementService
                .AddMeasurement(addMeasurementDto);

            return HandleResultResponse(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeasurementDto>>>
            GetMeasurementList( )
        {
            var results = await _measurementService
                .GetMeasurementList();

            return HandleResultResponse(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeasurementDto>>
            GetMeasurementById(int id)
        {
            var Measurement = await _measurementService.GetMeasurementById(id);
            return HandleResultResponse(Measurement);
        }

        [HttpDelete("{measurementId}")]
        public async Task<ActionResult<MeasurementDto>>
            DeleteMeasurement(int measurementId)
        {
            var measurement = await _measurementService.DeleteMeasurement(measurementId);
            return HandleResultResponse(measurement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>
            UpdateMeasurement(int id, MeasurementDto? measurementDto)
        {
            return HandleResult(await _measurementService.UpdateMeasurement(id, measurementDto));
        }
    }

   

}