using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.BL.ViewModels.Quizzes
{
    public class QuizDeleteVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        public QuizDeleteVM()
        {

        }
        public QuizDeleteVM(int id, string name, string description, string image, DateTime date)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Date = date;
        }
    }
}
