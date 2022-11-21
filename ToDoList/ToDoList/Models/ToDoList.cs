using System.Collections.Generic;

namespace ToDoList.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<DailyList> DailyLists { get; set; }
    }
}
