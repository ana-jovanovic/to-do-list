using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyList",
                columns: table => new
                {
                    DailyListId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyList", x => x.DailyListId);
                });

            migrationBuilder.CreateTable(
                name: "OneTask",
                columns: table => new
                {
                    TaskId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: false),
                    Done = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTask", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: false),
                    Done = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoList",
                columns: table => new
                {
                    ToDoListId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoList", x => x.ToDoListId);
                });

            migrationBuilder.CreateTable(
                name: "TaskDailyList",
                columns: table => new
                {
                    TaskId = table.Column<Guid>(nullable: false),
                    DailyListId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDailyList", x => new { x.TaskId, x.DailyListId });
                    table.ForeignKey(
                        name: "FK_TaskDailyList_DailyList_DailyListId",
                        column: x => x.DailyListId,
                        principalTable: "DailyList",
                        principalColumn: "DailyListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskDailyList_OneTask_TaskId",
                        column: x => x.TaskId,
                        principalTable: "OneTask",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDoListDailyList",
                columns: table => new
                {
                    DailyListId = table.Column<Guid>(nullable: false),
                    ToDoListId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoListDailyList", x => new { x.ToDoListId, x.DailyListId });
                    table.ForeignKey(
                        name: "FK_ToDoListDailyList_DailyList_DailyListId",
                        column: x => x.DailyListId,
                        principalTable: "DailyList",
                        principalColumn: "DailyListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoListDailyList_ToDoList_ToDoListId",
                        column: x => x.ToDoListId,
                        principalTable: "ToDoList",
                        principalColumn: "ToDoListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskDailyList_DailyListId",
                table: "TaskDailyList",
                column: "DailyListId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListDailyList_DailyListId",
                table: "ToDoListDailyList",
                column: "DailyListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TaskDailyList");

            migrationBuilder.DropTable(
                name: "ToDoListDailyList");

            migrationBuilder.DropTable(
                name: "OneTask");

            migrationBuilder.DropTable(
                name: "DailyList");

            migrationBuilder.DropTable(
                name: "ToDoList");
        }
    }
}
