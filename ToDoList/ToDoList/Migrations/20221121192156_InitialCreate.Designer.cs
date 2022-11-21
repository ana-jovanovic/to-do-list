﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.Context;

namespace ToDoList.Migrations
{
    [DbContext(typeof(ToDoListContext))]
    [Migration("20221121192156_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToDoList.Context.Models.DailyList", b =>
                {
                    b.Property<Guid>("DailyListId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("DailyListId");

                    b.ToTable("DailyList");
                });

            modelBuilder.Entity("ToDoList.Context.Models.OneTask", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Description");

                    b.Property<bool>("Done");

                    b.Property<string>("Title");

                    b.HasKey("TaskId");

                    b.ToTable("OneTask");
                });

            modelBuilder.Entity("ToDoList.Context.Models.TaskDailyList", b =>
                {
                    b.Property<Guid>("TaskId");

                    b.Property<Guid>("DailyListId");

                    b.HasKey("TaskId", "DailyListId");

                    b.HasIndex("DailyListId");

                    b.ToTable("TaskDailyList");
                });

            modelBuilder.Entity("ToDoList.Context.Models.ToDoList", b =>
                {
                    b.Property<Guid>("ToDoListId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("ToDoListId");

                    b.ToTable("ToDoList");
                });

            modelBuilder.Entity("ToDoList.Context.Models.ToDoListDailyList", b =>
                {
                    b.Property<Guid>("ToDoListId");

                    b.Property<Guid>("DailyListId");

                    b.HasKey("ToDoListId", "DailyListId");

                    b.HasIndex("DailyListId");

                    b.ToTable("ToDoListDailyList");
                });

            modelBuilder.Entity("ToDoList.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Description");

                    b.Property<bool>("Done");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("ToDoList.Context.Models.TaskDailyList", b =>
                {
                    b.HasOne("ToDoList.Context.Models.DailyList", "DailyList")
                        .WithMany("TaskDailyLists")
                        .HasForeignKey("DailyListId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ToDoList.Context.Models.OneTask", "Task")
                        .WithMany("TaskDailyLists")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ToDoList.Context.Models.ToDoListDailyList", b =>
                {
                    b.HasOne("ToDoList.Context.Models.DailyList", "DailyList")
                        .WithMany("ToDoListDailyLists")
                        .HasForeignKey("DailyListId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ToDoList.Context.Models.ToDoList", "ToDoList")
                        .WithMany("ToDoListDailyLists")
                        .HasForeignKey("ToDoListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
