using ApiCommonModel.Models.TaskSetting;
using Microsoft.AspNetCore.Mvc;
using SimpleCrudApi.Services;

namespace SimpleCrudApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskSettingController : ControllerBase
    {
        private readonly ITaskSettingService _tSettingService;
        public TaskSettingController(ITaskSettingService tSettingService)
        {
            _tSettingService = tSettingService;
        }
        [HttpGet]
        public ActionResult<List<AllTaskSettingDto>> GetAllTaskSettingDto()
        {
            return Ok(_tSettingService.GetAllSettingAsync());
        }
        [HttpGet("{taskCode}")]
        public ActionResult<AllTaskSettingDto> GetTaskSettingDto([FromRoute] string taskCode)
        {
            return Ok(_tSettingService.GetSettingAsync(taskCode));
        }
        [HttpPost]
        public ActionResult<AllTaskSettingDto> CreateTaskSetting([FromBody] NewTaskSettingDto dto)
        {
            return Ok(_tSettingService.CreateSettingAsync(dto));
        }
        [HttpPatch("{id}")]
        public ActionResult<AllTaskSettingDto> UpdateTaskSetting([FromRoute] int id, [FromBody] EditTaskSettingDto dto)
        {
            return Ok(_tSettingService.UpdateSettingAsync(dto, id));
        }
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteTaskSetting([FromRoute] int id)
        {
            return Ok(_tSettingService.DeleteSettingAsync(id));
        }
    }
}
