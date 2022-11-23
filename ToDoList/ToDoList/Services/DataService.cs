using System.Collections.Generic;
using System.Linq;
using ToDoList.Context;
using ToDoList.DTO;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services
{
    public class DataService : IDataService
    {
        private readonly ToDoListContext _context;

        public DataService(ToDoListContext context)
        {
            _context = context;
        }

        public IList<DTO.ToDoList> GetAllToDoLists()
        {
            // when having a user, grab all the lists from a user instead of all the lists, and iterate through each

            var allUsersLists = _context.ToDoList.ToList();
            var usersToDoLists = new List<DTO.ToDoList>();

            foreach (var userToDoList in allUsersLists)
            {
                var toDoLists = new DTO.ToDoList
                {
                    Id = userToDoList.ToDoListId,
                    Title = userToDoList.Title,
                    Description = userToDoList.Description,
                    DailyLists = new List<DailyList>()
                };

                var dailyListIds = _context.ToDoList
                    .Where(list => list.ToDoListId == userToDoList.ToDoListId)
                    .Join(_context.ToDoListDailyList, list => list.ToDoListId,
                        dailyListRelation => dailyListRelation.ToDoListId,
                        (list, dailyListRelation) => new { dailyListRelation.DailyListId })
                    .Select(x => x.DailyListId)
                    .ToList();

                foreach (var dailyListId in dailyListIds)
                {
                    var tasks = new List<DTO.Task>();

                    var dailyListWithTasks = _context.TaskDailyList.Where(tdl => tdl.DailyListId.Equals(dailyListId))
                        .Join(_context.Task, tdl => tdl.OneTaskId, t => t.OneTaskId,
                            (tdl, t) => new { tdl.DailyListId, t });

                    foreach (var pair in dailyListWithTasks)
                    {
                        tasks.Add(new DTO.Task
                        {
                            Id = pair.t.OneTaskId,
                            Title = pair.t.Title,
                            Description = pair.t.Description,
                            Deadline = pair.t.Deadline,
                            Done = pair.t.Done
                        });
                    }

                    toDoLists.DailyLists.Add(new DailyList
                    {
                        Id = dailyListId,
                        Tasks = tasks
                    });
                }

                usersToDoLists.Add(toDoLists);
            }

            return usersToDoLists;
        }

    }
}
