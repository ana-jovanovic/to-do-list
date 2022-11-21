using System;

namespace ToDoList.Context.Models
{
    public class TaskDailyList
    {
        public Guid TaskId { get; set; }
        public OneTask Task { get; set; }


        public Guid DailyListId { get; set; }
        public DailyList DailyList { get; set; }
    }
}
