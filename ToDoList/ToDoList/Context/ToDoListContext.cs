using Microsoft.EntityFrameworkCore;
using ToDoList.Context.Configurations;
using ToDoList.Context.Models;

namespace ToDoList.Context
{
    public class ToDoListContext : DbContext
    {
        public DbSet<Models.ToDoList> ToDoList { get; set; }
        // TO DO: remove daily list table
        // New daily list should only have reference in the TaskDailyList table and ToDoDailyListTable
        public DbSet<DailyList> DailyList { get; set; }
        public DbSet<OneTask> Task { get; set; }
        public DbSet<TaskDailyList> TaskDailyList { get; set; }
        public DbSet<ToDoListDailyList> ToDoListDailyList { get; set; }

        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskDailyList>().HasKey(x => new { x.OneTaskId, x.DailyListId });

            modelBuilder.Entity<TaskDailyList>()
                .HasOne(x => x.OneTask)
                .WithMany(x => x.TaskDailyLists)
                .HasForeignKey(x => x.OneTaskId);

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

            // add configurations for all the tables
            modelBuilder.ApplyConfiguration(new ToDoListConfiguration());
        }
    }
}
