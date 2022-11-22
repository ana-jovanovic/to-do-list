using System;
using System.Collections.Generic;

namespace ToDoList.DTO
{
    public class ToDoList
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<DailyList> DailyLists { get; set; }
    }
}
