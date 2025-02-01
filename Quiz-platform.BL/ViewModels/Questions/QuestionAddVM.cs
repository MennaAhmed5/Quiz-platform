using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.BL.ViewModels.Questions
{
    public class QuestionAddVM
    {
        [Required]
        public string QuestionText { get; set; } = string.Empty;
        [Required]
        public string AnswerType { get; set; } = string.Empty;
        [Required]
        public int QuizId { get; set; }
    }
}
