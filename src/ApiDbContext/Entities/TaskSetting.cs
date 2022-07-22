using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDbContext.Entities
{
    public class TaskSetting
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskUniqCode { get; set; }
        public string TaskPath { get; set; }
        public string TaskFileName { get; set; }
        public virtual List<TaskParameter> TaskParameters { get; set; }
    }
}
