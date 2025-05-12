using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Study.Model;
using ShiftLogger.Study.Model.Dto;
using ShiftLogger.Study.Services;

namespace ShiftLogger.Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftRepository repository;
        public ShiftsController(IShiftRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<Shift>>>> GetAllShiftsAsync()
        {
            var Data = await repository.GetAllShiftsAsync();
            if(Data==null)
            {
                return NotFound(ResponseDto<List<Shift>>.Success(Data, "No Data Found"));
            }
            return ResponseDto<List<Shift>>.Success(Data, "Successfully Fetched Data!");
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ResponseDto<Shift>>> GetShiftByIdAsync([FromRoute] int Id)
        {
            var Data= await repository.GetShiftByIdAsync(Id);
            if(Data==null)
            {
                return NotFound(ResponseDto<Shift>.Failure(Data, "No Data Found"));
            }
            return ResponseDto<Shift>.Success(Data, "Successfully Fetched The Data!!!");
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDto<Shift>>> GetShiftByIdAsync([FromBody]ShiftDto shift)
        {
            var NewShift=repository.CreateShift(shift);

            return CreatedAtAction(nameof(GetShiftByIdAsync), new { Id = NewShift.Id }, NewShift);
        }
    }
}
