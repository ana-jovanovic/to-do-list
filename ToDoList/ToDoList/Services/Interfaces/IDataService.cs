using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList.Services.Interfaces
{
    public interface IDataService
    {
        IList<DTO.ToDoList> GetAllToDoLists();
    }
}
