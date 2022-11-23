namespace ToDoList.Services.Interfaces
{
    public interface IToDoListService
    {
        Context.Models.ToDoList CreateNewToDoList(DTO.ToDoList toDoList);
    }
}
