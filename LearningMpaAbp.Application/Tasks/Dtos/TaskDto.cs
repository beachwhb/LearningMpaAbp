using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace LearningMpaAbp.Tasks.Dtos
{
    public class TaskDto:EntityDto
    {
        public long? AssignedPersonId { get; set; }
        public string AssignedPersonName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public TaskStatus State { get; set; }

        public override string ToString()
        {
            return $"[Task Id={Id}, Description={Description}, CreationTime={CreationTime}, AssignedPersonName={AssignedPersonId}, State={(TaskState) State}]";
        }
    }
}
