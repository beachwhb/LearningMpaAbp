using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Timing;
using AutoMapper;
using LearningMpaAbp.Tasks.Dtos;

namespace LearningMpaAbp.Tasks
{
    public class TaskAppService : LearningMpaAbpAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Task> _taskRepository;

        public TaskAppService(IRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public GetTasksOutput GetTasks(GetTasksInput input)
        {
            var query = _taskRepository.GetAll();

            if (input.AssignedPersonId.HasValue)
            {
                query = query.Where(t => t.AssignedPersonId == input.AssignedPersonId.Value);
            }
            if (input.State.HasValue)
            {
                query = query.Where(t => t.State == input.State.Value);
            }

            //使用AutoMapper自动转换 List<Task> to List<TaskDto>
            //从数据库返回的是实体的字段，返回给上一层的需要dto的字段
            return new GetTasksOutput
            {
                Tasks = Mapper.Map<List<TaskDto>>(query.ToList())
            };
        }

        public async System.Threading.Tasks.Task<TaskDto> GetTaskByIdAsync(int taskId)
        {
            //Called specific GetAllWithPeople method of task repository.
            var task = await _taskRepository.GetAsync(taskId);

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return task.MapTo<TaskDto>();
        }

        public TaskDto GetTaskById(int taskId)
        {
            var task = _taskRepository.Get(taskId);

            return task.MapTo<TaskDto>();
        }

        public void UpdateTask(UpdateTaskInput input)
        {
            Logger.Info("Updating a task for input: " + input);

            //
            var task = _taskRepository.Get(input.Id);

            //Updating changed properties of the retrieved task entity.
            if (input.State.HasValue)
            {
                task.State = input.State.Value;
            }
            //We even do not call Update method of the repository.
            //Because an application service method is a 'unit of work' scope as default.
            //ABP automatically saves all changes when a 'unit of work' scope ends (without any exception).

        }

        public int CreateTask(CreateTaskInput input)
        {
            Logger.Info("Creating a task for input: " + input);

            //Creating a new Task entity with given input's properties
            var task = new Task
            {
                Description = input.Description,
                Title = input.Title,
                State = input.State,
                CreationTime = Clock.Now
            };

            //Saving entity with standard Insert method of repositories.
            return _taskRepository.InsertAndGetId(task);
        }

        public void DeleteTask(int taskId)
        {
            var task = _taskRepository.Get(taskId);
            if (task != null)
            {
                _taskRepository.Delete(task);
            }
        }

        /// <summary>
        /// 获取所有任务
        /// </summary>
        /// <returns></returns>
        public IList<TaskDto> GetAllTasks()
        {
            var tasks = _taskRepository.GetAll().OrderByDescending(t => t.CreationTime);

            return Mapper.Map<IList<TaskDto>>(tasks.ToList());

        }
    }
}
