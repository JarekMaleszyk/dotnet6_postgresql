using ApiCommonModel.Models.TaskParameter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCrudApi.Services;

namespace SimpleCrudApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskParameterController : ControllerBase
    {
        private readonly ITaskParameterService _tParameterService;
        public TaskParameterController(ITaskParameterService tParameterService)
        {
            _tParameterService = tParameterService;
        }
        [HttpGet]
        public ActionResult<List<AllTaskParameterDto>> GetAllTaskParameterDto()
        {
            return Ok(_tParameterService.GetAllTaskParameter());
        }
        [HttpGet("{taskCode}")]
        public ActionResult<AllTaskParameterDto> GetTaskParameterDto([FromRoute] string taskCode)
        {
            return Ok(_tParameterService.GetAllTaskParameterForSetting(taskCode));
        }
        [HttpPost("{id}")]
        public ActionResult<AllTaskParameterDto> CreateTaskParameter([FromBody] NewTaskParameterDto dto, [FromRoute] int id)
        {
            return Ok(_tParameterService.CreateTaskParameter(dto, id));
        }
        [HttpPatch("{id}")]
        public ActionResult<AllTaskParameterDto> UpdateTaskParameter([FromBody] EditTaskParameterDto dto, [FromRoute] int id)
        {
            return Ok(_tParameterService.UpdateTaskParameter(dto, id));
        }
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteTaskParameter([FromRoute] int id)
        {
            return Ok(_tParameterService.DeleteTaskParameter(id));
        }
    }
}
