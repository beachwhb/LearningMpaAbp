using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;

namespace LearningMpaAbp.Tasks
{
    public class TaskAppService : IApplicationService
    {
        private readonly IRepository<Task> _taskRepository;

        public TaskAppService(IRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void GetAll()
        {
            var all = _taskRepository.Count();
        }

    }
}
