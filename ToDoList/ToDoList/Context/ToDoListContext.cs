using Microsoft.EntityFrameworkCore;
using ToDoList.Context.Models;
using Task = ToDoList.Models.Task;

namespace ToDoList.Context
{
    public class ToDoListContext : DbContext
    {
        public DbSet<Models.ToDoList> ToDoList { get; set; }
        public DbSet<DailyList> DailyList { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<TaskDailyList> TaskDailyList { get; set; }
        public DbSet<ToDoListDailyList> ToDoListDailyList { get; set; }

        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskDailyList>().HasKey(x => new { x.TaskId, x.DailyListId });

            modelBuilder.Entity<TaskDailyList>()
                .HasOne(x => x.Task)
                .WithMany(x => x.TaskDailyLists)
                .HasForeignKey(x => x.TaskId);

            modelBuilder.Entity<TaskDailyList>()
                .HasOne(x => x.DailyList)
                .WithMany(x => x.TaskDailyLists)
                .HasForeignKey(x => x.DailyListId);

            modelBuilder.Entity<ToDoListDailyList>().HasKey(x => new { x.ToDoListId, x.DailyListId });

            modelBuilder.Entity<ToDoListDailyList>()
                .HasOne(x => x.ToDoList)
                .WithMany(x => x.ToDoListDailyLists)
                .HasForeignKey(x => x.ToDoListId);

            modelBuilder.Entity<ToDoListDailyList>()
                .HasOne(x => x.DailyList)
                .WithMany(x => x.ToDoListDailyLists)
                .HasForeignKey(x => x.DailyListId);
        }
    }
}
