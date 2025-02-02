using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Quiz_platform.BL.ViewModels.Answers
{
    public class AnswerReadVM
    {
        public int Id { get; set; }
        [Required]
        public string OptionText { get; set; } = string.Empty;
        [Required]
        public bool IsCorrect { get; set; }
        [Required]
        [DisplayName("Question Name")]
        public int QuestionId { get; set; }

        public AnswerReadVM(int id, string optionText, bool isCorrect, int quizId)
        {
            Id = id;
            OptionText = optionText;
            IsCorrect = isCorrect;
            QuestionId = quizId;
        }
    }
}
