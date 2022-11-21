using System.Collections.Generic;

namespace ToDoList.Models
{
    public class DailyList
    {
        public int Id { get; set; }
        public int ToDoListId { get; set; }
        public IList<Task> Tasks { get; set; }
    }
}
