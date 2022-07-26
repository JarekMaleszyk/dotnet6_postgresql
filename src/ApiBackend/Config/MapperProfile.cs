using ApiCommonModel.Models.TaskParameter;
using ApiCommonModel.Models.TaskSetting;
using ApiDbContext.Entities;
using AutoMapper;

namespace SimpleCrudApi.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TaskSetting, AllTaskSettingDto>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
               .ForMember(x => x.TaskName, y => y.MapFrom(z => z.TaskName))
               .ForMember(x => x.TaskDescription, y => y.MapFrom(z => z.TaskDescription))
               .ForMember(x => x.TaskUniqCode, y => y.MapFrom(z => z.TaskUniqCode))
               .ForMember(x => x.TaskPath, y => y.MapFrom(z => z.TaskPath))
               .ForMember(x => x.TaskFileName, y => y.MapFrom(z => z.TaskFileName))
               .ForMember(x => x.TaskParameters, y => y.MapFrom(z => z.TaskParameters))
               .ReverseMap();

            CreateMap<EditTaskSettingDto, TaskSetting>();

            CreateMap<NewTaskSettingDto, TaskSetting>();

            CreateMap<TaskParameter, AllTaskParameterDto>();

            CreateMap<AllTaskParameterDto, TaskParameter>();

            CreateMap<NewTaskParameterDto, TaskParameter>();
            //.ForMember(x => x.ParameterName, y => y.MapFrom(z => z.ParameterName));

        }
    }
}
