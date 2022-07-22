using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCommonModel.Models.TaskParameter
{
    public class FindTaskParameterDto
    {
        public string ParameterName { get; set; }
        public int TaskSetting { get; set; }
    }
}
