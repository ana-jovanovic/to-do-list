using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Migrations
{
    public partial class RenameTaskVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDailyList_OneTask_TaskId",
                table: "TaskDailyList");

            migrationBuilder.DropTable(
                name: "OneTask");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "TaskDailyList",
                newName: "OneTaskId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Task",
                newName: "OneTaskId");

            migrationBuilder.InsertData(
                table: "ToDoList",
                columns: new[] { "ToDoListId", "Description", "Title" },
                values: new object[] { new Guid("1f69c0ca-560c-42ae-972d-d2650ee41c63"), "List of chores", "My todo list" });

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDailyList_Task_OneTaskId",
                table: "TaskDailyList",
                column: "OneTaskId",
                principalTable: "Task",
                principalColumn: "OneTaskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskDailyList_Task_OneTaskId",
                table: "TaskDailyList");

            migrationBuilder.DeleteData(
                table: "ToDoList",
                keyColumn: "ToDoListId",
                keyValue: new Guid("1f69c0ca-560c-42ae-972d-d2650ee41c63"));

            migrationBuilder.RenameColumn(
                name: "OneTaskId",
                table: "TaskDailyList",
                newName: "TaskId");

            migrationBuilder.RenameColumn(
                name: "OneTaskId",
                table: "Task",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "OneTask",
                columns: table => new
                {
                    TaskId = table.Column<Guid>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Done = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTask", x => x.TaskId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDailyList_OneTask_TaskId",
                table: "TaskDailyList",
                column: "TaskId",
                principalTable: "OneTask",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
