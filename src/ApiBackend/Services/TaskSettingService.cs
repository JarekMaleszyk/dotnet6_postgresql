using ApiCommonModel.Models.TaskSetting;
using ApiDbContext.Context;
using ApiDbContext.Entities;
using AutoMapper;

namespace SimpleCrudApi.Services
{
    public interface ITaskSettingService
    {
        List<AllTaskSettingDto> GetAllSettingAsync();
        List<AllTaskSettingDto> GetSettingAsync(string taskUniqCode);
        AllTaskSettingDto UpdateSettingAsync(EditTaskSettingDto dto, int id);
        bool DeleteSettingAsync(int id);
        AllTaskSettingDto CreateSettingAsync(NewTaskSettingDto dto);
    }
    public class TaskSettingService : ITaskSettingService
    {
        private readonly ApiDatabaseContext _context;
        private readonly IMapper _mapper;
        public TaskSettingService(ApiDatabaseContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public AllTaskSettingDto CreateSettingAsync(NewTaskSettingDto dto)
        {
            var newTaskSetting = _mapper.Map<TaskSetting>(dto); //map

            _context.Add(newTaskSetting); //add newEntityEntry
            _context.SaveChanges(); //save newEntityEntry

            return _mapper.Map<AllTaskSettingDto>(newTaskSetting); //remap
        }

        public bool DeleteSettingAsync(int id)
        {
            var toDelete = _context.TaskSettings.FirstOrDefault(x => x.Id == id);

            try
            {
                _context.Remove(toDelete);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<AllTaskSettingDto> GetAllSettingAsync()
        {
            return _mapper.Map<List<AllTaskSettingDto>>(_context.TaskSettings.ToList());
        }

        public List<AllTaskSettingDto> GetSettingAsync(string taskUniqCode)
        {
            return _mapper.Map<List<AllTaskSettingDto>>(_context.TaskSettings.Where(x => x.TaskUniqCode == taskUniqCode).ToList());
        }

        public AllTaskSettingDto UpdateSettingAsync(EditTaskSettingDto dto, int id)
        {
            var taskSetting = _context.TaskSettings.FirstOrDefault(x => x.Id == id);
            if (taskSetting == null)
                throw new Exception();

            taskSetting.TaskName = dto.TaskName;
            taskSetting.TaskDescription = dto.TaskDescription;
            taskSetting.TaskPath = dto.TaskPath;
            taskSetting.TaskFileName = dto.TaskFileName;

            _context.Update(taskSetting); 
            _context.SaveChanges(); 

            return _mapper.Map<AllTaskSettingDto>(taskSetting); //remap
        }
    }
}
