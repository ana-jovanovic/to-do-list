using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Context;
using ToDoList.Context.Models;
using ToDoList.DTO;
using ToDoList.Services.Interfaces;
using DailyList = ToDoList.DTO.DailyList;

namespace ToDoList.Services
{
    public class DataService : IDataService
    {
        private readonly ToDoListContext _context;
        private const int ItemsPerPageDefault = 10;

        public DataService(ToDoListContext context)
        {
            _context = context;
        }

        public IList<DTO.ToDoList> GetAllToDoLists(RequestParameters parameters)
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
                            (tdl, t) => new DailyListWithTask
                            {
                                DailyListId = tdl.DailyListId,
                                OneTaskId = t.OneTaskId,
                                Title = t.Title,
                                Description = t.Description,
                                Deadline = t.Deadline,
                                Done = t.Done
                            });

                    if (!string.IsNullOrEmpty(parameters.Title))
                    {
                        dailyListWithTasks = dailyListWithTasks.Where(x => x.Title.Equals(parameters.Title));
                    }

                    if (parameters.Date != null)
                    {
                        dailyListWithTasks = dailyListWithTasks.Where(x => x.Deadline.Equals(parameters.Date));
                    }

                    dailyListWithTasks = dailyListWithTasks
                        .Skip(parameters.Page > 0 ? (parameters.Page - 1) * ItemsPerPageDefault : 0)
                        .Take(ItemsPerPageDefault);

                    if (!dailyListWithTasks.Any()) continue;

                    foreach (var task in dailyListWithTasks)
                    {
                        tasks.Add(new DTO.Task
                        {
                            Id = task.OneTaskId,
                            Title = task.Title,
                            Description = task.Description,
                            Deadline = task.Deadline,
                            Done = task.Done
                        });
                    }

                    toDoLists.DailyLists.Add(new DailyList
                    {
                        Id = dailyListId,
                        Tasks = tasks
                    });
                }

                if (!toDoLists.DailyLists.Any()) continue;

                usersToDoLists.Add(toDoLists);
            }

            return usersToDoLists;
        }

    }
}
