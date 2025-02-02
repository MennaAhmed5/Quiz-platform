using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Quiz_platform.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuizId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Quizes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Quizes",
                columns: new[] { "Id", "Date", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test your knowledge of C# fundamentals, including syntax, data types, and OOP concepts", "Images\\Quizzes\\csharp.png", "C# Basics Quiz" },
                    { 2, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A quiz covering Java syntax, OOP concepts, and basic Java programming principles.", "Images\\Quizzes\\java.png", "Java Fundamentals" },
                    { 3, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "A quiz covering Python syntax, data structures, and basic algorithms.", "Images\\Quizzes\\python.png", "Python for Beginners" },
                    { 4, new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Check your knowledge on SQL queries, normalization, and database management.", "Images\\Quizzes\\sql.png", "SQL & Databases" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AnswerType", "QuestionText", "QuizId" },
                values: new object[,]
                {
                    { 1, "Choices", "What is the correct syntax to declare a variable in C#?", 1 },
                    { 2, "Text", "Explain the concept of polymorphism in C#.", 1 },
                    { 3, "Choices", "What is the default value of an uninitialized int variable in Java?", 2 },
                    { 4, "Text", "Describe the differences between 'ArrayList' and 'LinkedList' in Java.", 2 },
                    { 5, "Choices", "Which built-in function in Python is used to get the length of a list?", 3 },
                    { 6, "Text", "Explain the concept of list comprehensions in Python.", 3 },
                    { 7, "choice", "Which SQL command is used to remove all records from a table but keep the structure?", 4 },
                    { 8, "Text", "Explain the difference between INNER JOIN and LEFT JOIN in SQL.", 4 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "IsCorrect", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { 1, true, "int x = 5;", 1 },
                    { 2, false, "x := 5;", 1 },
                    { 3, false, "declare x = 5;", 1 },
                    { 4, true, "0", 3 },
                    { 5, false, "null", 3 },
                    { 6, false, "undefined", 3 },
                    { 7, true, "len()", 5 },
                    { 8, false, "size()", 5 },
                    { 9, false, "count()", 5 },
                    { 10, true, "TRUNCATE", 7 },
                    { 11, false, "DELETE", 7 },
                    { 12, false, "DROP", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Quizes");
        }
    }
}
