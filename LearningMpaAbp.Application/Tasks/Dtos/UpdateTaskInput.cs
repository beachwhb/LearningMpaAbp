using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Runtime.Validation;

namespace LearningMpaAbp.Tasks.Dtos
{
    /// <summary>
    /// 更新任务输入参数模型
    /// </summary>
    public class UpdateTaskInput : ICustomValidate
    {
        [Range(1, Int32.MaxValue)]
        public int Id { get; set; }

        public int? AssignedPersonId { get; set; }
        public TaskState? State { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (AssignedPersonId == null && State == null)
            {
                context.Results.Add(new ValidationResult("Both of AssignedPersonId and State can not be null in order to update a Task!", new[] { "AssignedPersonId", "State" }));

            }
        }

        public override string ToString()
        {
            return $"[UpdateTaskInput > TaskId = {Id}, AssignedPersonId = {AssignedPersonId}, State = {State}]";
        }
    }
}
