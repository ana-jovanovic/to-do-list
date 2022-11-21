using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Context.Models
{
    public class OneTask
    {
        [Key]
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool Done { get; set; }
        public ICollection<TaskDailyList> TaskDailyLists { get; set; }
    }
}
