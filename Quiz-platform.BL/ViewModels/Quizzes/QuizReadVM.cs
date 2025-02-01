using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.BL.ViewModels.Quizzes
{
    public class QuizReadVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public QuizReadVM(int id,  string name, string description, DateTime date)
        {
            Id = id;
            Name = name;
            Description = description; 
            Date = date;    
        }
    }
}
