using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoFundamentosEF.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("45f3c893-8e07-4e4c-9f34-fd63f9552636"), "Category about learn activities", "Learn", 8 },
                    { new Guid("d22d110c-1064-4a0a-a654-1f5a0f0856ea"), "Category about financial activities", "Financial", 10 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreatedAt", "Description", "PriorityTask", "Title" },
                values: new object[,]
                {
                    { new Guid("18c6b94f-5344-436b-b102-0301e98b1728"), new Guid("d22d110c-1064-4a0a-a654-1f5a0f0856ea"), new DateTime(2022, 12, 13, 6, 23, 20, 362, DateTimeKind.Utc).AddTicks(1589), null, 3, "Check bills of gifts" },
                    { new Guid("90a13ed7-c79f-4a67-a081-bbef420fcf0b"), new Guid("45f3c893-8e07-4e4c-9f34-fd63f9552636"), new DateTime(2022, 12, 13, 6, 23, 20, 362, DateTimeKind.Utc).AddTicks(1593), null, 1, "Learn about compound interest" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("18c6b94f-5344-436b-b102-0301e98b1728"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("90a13ed7-c79f-4a67-a081-bbef420fcf0b"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("45f3c893-8e07-4e4c-9f34-fd63f9552636"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("d22d110c-1064-4a0a-a654-1f5a0f0856ea"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
