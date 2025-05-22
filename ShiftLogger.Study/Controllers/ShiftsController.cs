using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Study.Model;
using ShiftLogger.Study.Model.Dto;
using ShiftLogger.Study.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            List<Shift> Data = null;
            try
            {
                Data = await repository.GetAllShiftsAsync();
                if (Data == null)
                {
                    return NotFound(ResponseDto<List<Shift>>.Success(Data, "No Data Found"));
                }
                return ResponseDto<List<Shift>>.Success(Data, "Successfully Fetched Data!");
            }
            catch(Exception e)
            {
                return ResponseDto<List<Shift>>.Failure(Data, e.Message);
            }
        }
        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<ResponseDto<Shift>>> GetShiftByIdAsync([FromRoute] int Id)
        {
            Shift Data = null;
            try
            {
                Data = await repository.GetShiftByIdAsync(Id);
                if (Data == null)
                {
                    return NotFound(ResponseDto<Shift>.Failure(Data, "No Data Found"));
                }
                return ResponseDto<Shift>.Success(Data, "Successfully Fetched The Data!!!");
            }
            catch(Exception e)
            {
               return ResponseDto<Shift>.Failure(Data, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<ResponseDto<ShiftDto>>> CreateShiftAsync([FromBody]ShiftDto shift)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ResponseDto<ShiftDto>.Failure(shift, "Bad Data!! Please give the Properties for Shift with valid format");
                }
                var NewShift = await repository.CreateShift(shift);
                return Ok(ResponseDto<ShiftDto>.Success(shift, "Successfully Created Shift"));
            }
            catch(Exception e)
            {
                return ResponseDto<ShiftDto>.Failure(shift, e.Message);
            }
        }
        [HttpPut]
        [Route("{Id:int}")]
        public async Task<ActionResult<ResponseDto<Shift>>> UpdateShiftAsync([FromBody] ShiftDto shift, [FromRoute] int Id)
        {
            Shift UpdatedShift = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    return ResponseDto<Shift>.Failure(UpdatedShift, "Bad Data!! Please give the Properties for Shift with valid format");
                }
                UpdatedShift = await repository.UpdateShiftAsync(shift, Id);
                return Ok(ResponseDto<Shift>.Success(UpdatedShift, "Succefully Updated"));
            }
            catch (Exception e)
            {
                return ResponseDto<Shift>.Failure(UpdatedShift, e.Message);
            }
        }
        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult<ResponseDto<Shift>>> DeleteShiftAsync([FromRoute] int Id)
        {
            Shift DeleteShift = null;
            try
            {
                DeleteShift = await repository.DeleteShiftAsync(Id);
                if (DeleteShift == null)
                {
                    return (ResponseDto<Shift>.Failure(DeleteShift, "No Shift is available!!!"));
                }
                return Ok(ResponseDto<Shift>.Success(DeleteShift, "Shift is successfully Deleted"));
            }
            catch (Exception e)
            {
                return ResponseDto<Shift>.Failure(DeleteShift, e.Message);
            }
        }
    }
}
