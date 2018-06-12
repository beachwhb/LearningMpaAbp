using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using LearningMpaAbp.Tasks.Dtos;

namespace LearningMpaAbp.Tasks
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITaskAppService : IApplicationService
    {
        /// <summary>
        /// 根据多条件搜索任务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        GetTasksOutput GetTasks(GetTasksInput input);

        void UpdateTask(UpdateTaskInput input);

        int CreateTask(CreateTaskInput input);

        Task<TaskDto> GetTaskByIdAsync(int taskId);

        TaskDto GetTaskById(int taskId);

        void DeleteTask(int taskId);

        IList<TaskDto> GetAllTasks();
    }
}
