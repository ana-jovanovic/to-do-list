using System;
using System.Collections.Generic;

namespace ToDoList.Models
{
    public class DailyList
    {
        public Guid Id { get; set; }
        public IList<Task> Tasks { get; set; }
    }
}
