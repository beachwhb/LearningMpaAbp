using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Task = LearningMpaAbp.Tasks.Task;

namespace LearningMpaAbp.IRepositories
{
    /// <summary>
    /// 自定义仓储接口
    /// </summary>
    public interface IBackendTaskRepository : IRepository<Task>
    {
        /// <summary>
        /// 根据受配人的ID，找出他所有的任务
        /// </summary>
        /// <param name="personId">受配人的ID</param>
        /// <returns></returns>
        List<Task> GetTaskByAssignedPersonId(long personId);
    }
}
