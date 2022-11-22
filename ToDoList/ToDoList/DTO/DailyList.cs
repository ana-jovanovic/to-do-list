using System;
using System.Collections.Generic;

namespace ToDoList.DTO
{
    public class DailyList
    {
        public Guid Id { get; set; }
        public IList<Task> Tasks { get; set; }
    }
}
