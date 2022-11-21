using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Context.Models
{
    public class ToDoList
    {
        [Key]
        public Guid ToDoListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<ToDoListDailyList> ToDoListDailyLists { get; set; }
    }
}
