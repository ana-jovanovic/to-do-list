using System;

namespace ToDoList.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public int DailyListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool Done { get; set; }
    }
}
