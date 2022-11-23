using System;

namespace ToDoList.DTO
{
    public class DailyListWithTask
    {
        public Guid DailyListId { get; set; }
        public Guid OneTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool Done { get; set; }
    }
}
