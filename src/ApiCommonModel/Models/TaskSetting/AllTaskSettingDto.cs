using ApiCommonModel.Models.TaskParameter;
using System.Collections.Generic;

namespace ApiCommonModel.Models.TaskSetting
{
    public class AllTaskSettingDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskUniqCode { get; set; }
        public string TaskPath { get; set; }
        public string TaskFileName { get; set; }
        public List<AllTaskParameterDto> TaskParameters { get; set; }
    }
}
