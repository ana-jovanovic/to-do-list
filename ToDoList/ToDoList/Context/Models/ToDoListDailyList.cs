using System;

namespace ToDoList.Context.Models
{
    public class ToDoListDailyList
    {
        public Guid DailyListId { get; set; }
        public DailyList DailyList { get; set; }


        public Guid ToDoListId { get; set; }
        public ToDoList ToDoList { get; set; }
    }
}
