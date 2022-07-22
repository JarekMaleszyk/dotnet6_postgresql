using ApiCommonModel.Models.TaskParameter;
using ApiDbContext.Context;
using ApiDbContext.Entities;
using AutoMapper;

namespace SimpleCrudApi.Services
{
    public interface ITaskParameterService
    {
        AllTaskParameterDto CreateTaskParameter(NewTaskParameterDto dto, int tSettingId);
        List<AllTaskParameterDto> GetAllTaskParameter();
        List<AllTaskParameterDto> GetAllTaskParameterForSetting(string settingCode);
        AllTaskParameterDto UpdateTaskParameter(EditTaskParameterDto dto, int id);
        bool DeleteTaskParameter(int id);
    }
    public class TaskParameterService : ITaskParameterService
    {
        private readonly ApiDatabaseContext _context;
        private readonly IMapper _mapper;
        public TaskParameterService(ApiDatabaseContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public AllTaskParameterDto CreateTaskParameter(NewTaskParameterDto dto, int tSettingId)
        {
            if(_context.TaskSettings.FirstOrDefault(x => x.Id == tSettingId) == null)
                return null;

            var tParameter = _mapper.Map<TaskParameter>(dto);
            tParameter.TaskSetingId = tSettingId;

            _context.TaskParameters.Add(tParameter);
            _context.SaveChanges();

            return _mapper.Map<AllTaskParameterDto>(tParameter);
        }

        public bool DeleteTaskParameter(int id)
        {
            var toRemove = _context.TaskParameters.FirstOrDefault(x => x.Id == id);

            if (toRemove == null)
                return false;
            try
            {
                _context.Remove(toRemove);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<AllTaskParameterDto> GetAllTaskParameter()
        {
            var result = _context.TaskParameters.ToList();

            return _mapper.Map<List<AllTaskParameterDto>>(result);
        }

        public List<AllTaskParameterDto> GetAllTaskParameterForSetting(string settingCode)
        {
            var result = _context.TaskParameters.Where(x => x.TaskSeting.TaskUniqCode == settingCode).ToList();

            return _mapper.Map<List<AllTaskParameterDto>>(result);
        }

        public AllTaskParameterDto UpdateTaskParameter(EditTaskParameterDto dto, int id)
        {
            var result = _context.TaskParameters.FirstOrDefault(x => x.Id == id);

            result.ParameterOrder = dto.ParameterOrder;
            result.ParameterValue = dto.ParameterValue;
            result.ParameterName = dto.ParameterName;
            result.ParameterDescription = dto.ParameterDescription;

            _context.TaskParameters.Update(result);
            _context.SaveChanges();

            return _mapper.Map<AllTaskParameterDto>(result);
        }
    }
}
