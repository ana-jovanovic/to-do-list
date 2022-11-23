using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using ToDoList.Services.Interfaces;

namespace ToDoList.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class ToDoApiController : ControllerBase
    {
        private readonly IDataService _dataService;

        public ToDoApiController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // GET: api/ToDoApi
        [HttpGet]
        public string Get()
        {
            var toDoLists = _dataService.GetAllToDoLists();
            return JsonConvert.SerializeObject(toDoLists);
        }

        // GET: api/ToDoApi/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ToDoApi
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
