using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.BL.ViewModels.Quizzes
{
    public class QuizEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;

        public QuizEditVM()
        {

        }
        public QuizEditVM(int id, string name, string description, string image, DateTime date)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Date = date;
        }
    }
}
