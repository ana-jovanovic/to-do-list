using System;

namespace ToDoList.Context.Models
{
    public class TaskDailyList
    {
        public Guid OneTaskId { get; set; }
        public OneTask OneTask { get; set; }


        public Guid DailyListId { get; set; }
        public DailyList DailyList { get; set; }
    }
}
