using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDoList.Context.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class ToDoApiController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IToDoListService _toDoListService;

        public ToDoApiController(IDataService dataService, IToDoListService toDoListService)
        {
            _dataService = dataService;
            _toDoListService = toDoListService;
        }

        // GET: api/ToDo
        [HttpGet]
        public string Get([FromQuery] RequestParameters parameters)
        {
            var toDoLists = _dataService.GetAllToDoLists(parameters);
            return JsonConvert.SerializeObject(toDoLists);
        }

        // POST: api/ToDoApi
        [HttpPost]
        public void Post([FromBody] DTO.ToDoList toDoList)
        {
            if (toDoList == null)
            {
                return;
            }

            var list = _toDoListService.CreateNewToDoList(toDoList);
            _dataService.CreateToDoList(list);

        }

        // PUT: api/ToDoApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
