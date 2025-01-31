using Microsoft.EntityFrameworkCore;
using Quiz_platform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Quiz_platform.DAL.Data.Context
{
    public class QuizContext : DbContext
    {
        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public QuizContext(DbContextOptions Options) : base(Options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region seeding 
            #region Quizes

            var Quizes = new List<Quiz>
            {
                  new Quiz 
                  { 
                      Id= 1, 
                      Name= "C# Basics Quiz",
                      Description="Test your knowledge of C# fundamentals, including syntax, data types, and OOP concepts" , 
                      Image="csharp.png", 
                      Date= new DateTime(2025, 5, 5)
                  },
                  new Quiz 
                  { 
                      Id= 2, 
                      Name= "Java Fundamentals",
                      Description="A quiz covering Java syntax, OOP concepts, and basic Java programming principles." ,
                      Image="java.png", 
                      Date= new DateTime(2025, 2, 5)
                  },
                  new Quiz 
                  { 
                      Id= 3, 
                      Name= "Python for Beginners",
                      Description="A quiz covering Python syntax, data structures, and basic algorithms." , 
                      Image="python.png", 
                      Date= new DateTime(2025, 6, 6)
                  },
                  new Quiz 
                  {  
                      Id= 4,
                      Name= "SQL & Databases",
                      Description="Check your knowledge on SQL queries, normalization, and database management." , 
                      Image="sql.png", 
                      Date= new DateTime(2025, 8, 8)},

            };
            #endregion

            #region Questions

            var Questions = new List<Question>
            {
                  new Question 
                  { 
                      Id= 1, 
                      QuestionText= "What is the correct syntax to declare a variable in C#?",
                      AnswerType= "Choices", 
                      QuizId=1
                  },
                  new Question 
                  { 
                      Id= 2, 
                      QuestionText= "Explain the concept of polymorphism in C#.",
                      AnswerType="Text" ,  
                      QuizId=1
                  },
                  new Question 
                  { 
                      Id= 3, 
                      QuestionText= "What is the default value of an uninitialized int variable in Java?",
                      AnswerType="Choices", 
                      QuizId=2
                  },
                  new Question 
                  { 
                      Id= 4, 
                      QuestionText= "Describe the differences between 'ArrayList' and 'LinkedList' in Java.", 
                      AnswerType="Text" ,
                      QuizId = 2
                  },
                  new Question
                  {
                      Id= 5,
                      QuestionText= "Which built-in function in Python is used to get the length of a list?",
                      AnswerType="Choices" ,
                      QuizId = 3
                  },
                  new Question
                  {
                      Id= 6,
                      QuestionText= "Explain the concept of list comprehensions in Python.",
                      AnswerType="Text" ,
                      QuizId = 3
                  },
                  new Question
                  {
                      Id= 7,
                      QuestionText= "Which SQL command is used to remove all records from a table but keep the structure?",
                      AnswerType="choice" ,
                      QuizId = 4
                  },
                  new Question
                  {
                      Id= 8,
                      QuestionText= "Explain the difference between INNER JOIN and LEFT JOIN in SQL.",
                      AnswerType="Text" ,
                      QuizId = 4
                  },

            };
            #endregion

            #region Answers
            var Answers = new List<Answer>
            {
                     new Answer { Id = 1, QuestionId = 1, OptionText = "int x = 5;", IsCorrect = true },
                     new Answer { Id = 2, QuestionId = 1, OptionText = "x := 5;", IsCorrect = false },
                     new Answer { Id = 3, QuestionId = 1, OptionText = "declare x = 5;", IsCorrect = false },

                     new Answer { Id = 4, QuestionId = 3, OptionText = "0", IsCorrect = true },
                     new Answer { Id = 5, QuestionId = 3, OptionText = "null", IsCorrect = false },
                     new Answer { Id = 6, QuestionId = 3, OptionText = "undefined", IsCorrect = false },

                     new Answer { Id = 7, QuestionId = 5, OptionText = "len()", IsCorrect = true },
                     new Answer { Id = 8, QuestionId = 5, OptionText = "size()", IsCorrect = false },
                     new Answer { Id = 9, QuestionId = 5, OptionText = "count()", IsCorrect = false },

                     new Answer { Id = 10, QuestionId = 7, OptionText = "TRUNCATE", IsCorrect = true },
                     new Answer { Id = 11, QuestionId = 7, OptionText = "DELETE", IsCorrect = false },
                     new Answer { Id = 12, QuestionId = 7, OptionText = "DROP", IsCorrect = false }

            };

            #endregion

            #endregion

        }
    }
}
