using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Context;
using ToDoList.Context.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IDataService _dataService;
        private readonly ToDoListContext _context;

        public ToDoListService(IDataService dataService, ToDoListContext context)
        {
            _dataService = dataService;
            _context = context;
        }

        public Context.Models.ToDoList CreateNewToDoList(DTO.ToDoList toDoList)
        {
            return MapToDoList(toDoList);
        }

        public Context.Models.ToDoList MapToDoList(DTO.ToDoList toDoList)
        {
            var toDoListId = Guid.NewGuid();

            var toDo = new Context.Models.ToDoList
            {
                ToDoListId = toDoListId,
                Title = toDoList.Title,
                Description = toDoList.Description,
            };

            toDo.ToDoListDailyLists = MapDailyList(toDoList, toDoListId).Select(x => new ToDoListDailyList
            {
                ToDoListId = toDoListId,
                ToDoList = toDo,
                DailyListId = x.DailyListId,
                DailyList = x
            }).ToList();

            return toDo;
        }

        public IList<DailyList> MapDailyList(DTO.ToDoList toDoList, Guid toDoListId)
        {
            var lists = new List<DailyList>();
            if (toDoList.DailyLists == null || !toDoList.DailyLists.Any()) return lists;

            foreach (var dailyList in toDoList.DailyLists)
            {
                if (dailyList.Tasks == null) continue;

                var dailyListId = Guid.NewGuid();

                var list = new DailyList
                {
                    DailyListId = dailyListId,
                    ToDoListDailyLists = new List<ToDoListDailyList>
                    {
                        new ToDoListDailyList
                        {
                            DailyListId = dailyListId,
                            ToDoListId = toDoListId
                        }
                    }
                };

                list.TaskDailyLists = MapTasks(dailyList).Select(x => new TaskDailyList
                {
                    DailyListId = dailyListId,
                    DailyList = list,
                    OneTaskId = x.OneTaskId,
                    OneTask = x
                }).ToList();

                lists.Add(list);
            }

            return lists;
        }

        public IList<OneTask> MapTasks(DTO.DailyList dailyList)
        {
            return dailyList.Tasks.Select(x => new OneTask
            {
                OneTaskId = Guid.NewGuid(),
                Title = x.Title,
                Description = x.Description,
                Deadline = x.Deadline,
                Done = x.Done
            }).ToList();
        }
    }
}
