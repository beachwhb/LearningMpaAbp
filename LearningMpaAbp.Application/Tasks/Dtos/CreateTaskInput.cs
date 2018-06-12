using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;

namespace LearningMpaAbp.Tasks.Dtos
{
    /// <summary>
    /// 创建任务输入参数模型
    /// </summary>
    public class CreateTaskInput
    {
        public int? AssignedPersonId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }

        public TaskState State { get; set; }
        public override string ToString()
        {
            return $"[CreateTaskInput > AssignedPersonId = {AssignedPersonId}, Description = {Description}]";
        }
    }
}
