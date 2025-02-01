using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.BL.ViewModels.Quizzes
{
    public class QuizAddVM
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.Now;

    }
}
