﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCommonModel.Models.TaskSetting
{
    public class EditTaskSettingDto
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string TaskPath { get; set; }
        public string TaskFileName { get; set; }
    }
}