using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMpaAbp.Tasks.Dtos
{
    /// <summary>
    /// 多条件查询任务输入参数模型
    /// </summary>
    public class GetTasksInput
    {

        public TaskState? State { get; set; }

        public int? AssignedPersonId { get; set; }
    }
}
