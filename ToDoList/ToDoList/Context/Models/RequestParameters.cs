using System;

namespace ToDoList.Context.Models
{
    public class RequestParameters
    {
        public DateTime? Date { get; set; }
        public string Title { get; set; }
        public int Page { get; set; }
    }
}
