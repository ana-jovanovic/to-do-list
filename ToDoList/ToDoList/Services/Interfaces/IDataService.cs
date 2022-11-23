using System.Collections.Generic;
using ToDoList.Context.Models;

namespace ToDoList.Services.Interfaces
{
    public interface IDataService
    {
        IList<DTO.ToDoList> GetAllToDoLists(RequestParameters parameters);
    }
}
