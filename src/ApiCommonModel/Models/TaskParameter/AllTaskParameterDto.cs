using ApiCommonModel.Models.TaskSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCommonModel.Models.TaskParameter
{
    public class AllTaskParameterDto
    {
        public int Id { get; set; }
        public string ParameterName { get; set; }
        public string ParameterDescription { get; set; }
        public string ParameterValue { get; set; }
        public int ParameterOrder { get; set; }
    }
}
