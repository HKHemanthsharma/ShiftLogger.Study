using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Study.Model;
using ShiftLogger.Study.Model.Dto;
using ShiftLogger.Study.Services;

namespace ShiftLogger.Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerRepository Repository;
        public WorkerController(IWorkerRepository repo)
        {
            Repository = repo;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<Worker>>>> GetAllWorkersAsync()
        {
            List<Worker> Workers= await Repository.GetAllWorkerAsync();
            if(Workers==null)
            {
                return NotFound(ResponseDto<List<Worker>>.Failure(Workers,"No Workers Found"));
            }
            return Ok(ResponseDto<List<Worker>>.Success(Workers, "Successfully Fetched Workers"));
        }
        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<ResponseDto<Worker>>> GetWorkerAsync([FromRoute] int Id)
        {
            Worker Worker = await Repository.GetWorkerAsync(Id);
            if (Worker == null)
            {
                return NotFound(ResponseDto<Worker>.Failure(Worker, "No Worker Found"));
            }
            return Ok(ResponseDto<Worker>.Success(Worker, "Successfully Fetched Worker"));
        }
        [HttpPost]
        public async Task<ActionResult> CreateWorkerAsync([FromBody] WorkerDto NewWorker)
        {
            Worker Worker = await Repository.CreateWorkerAsync(NewWorker);
            return CreatedAtAction(nameof(GetWorkerAsync), new{Id=Worker.WorkerId},Worker);
        }
        [HttpPut]
        [Route("{Id:int}")]
        public async Task<ActionResult<ResponseDto<Worker>>> GetWorkerAsync([FromRoute] int Id, [FromBody]WorkerDto UpdateWorker)
        {
            Worker Worker = await Repository.UpdateWorkerAsync(UpdateWorker, Id);
            if (Worker == null)
            {
                return NotFound(ResponseDto<Worker>.Failure(Worker, "No Worker Found"));
            }
            return Ok(ResponseDto<Worker>.Success(Worker, "Successfully Fetched Worker"));
        }
        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult<ResponseDto<Worker>>> DeleteWorkerAsync([FromRoute] int Id)
        {
            Worker Worker = await Repository.DeleteWorkerAsync(Id);
            if (Worker == null)
            {
                return NotFound(ResponseDto<Worker>.Failure(Worker, "No Worker Found"));
            }
            return Ok(ResponseDto<Worker>.Success(Worker, "Successfully Deleted Worker"));
        }
    }
}
