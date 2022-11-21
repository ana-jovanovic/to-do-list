using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Context.Models
{
    public class DailyList
    {
        [Key]
        public Guid DailyListId { get; set; }
        public IList<TaskDailyList> TaskDailyLists { get; set; }
        public IList<ToDoListDailyList> ToDoListDailyLists { get; set; }
    }
}
