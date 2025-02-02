using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Quiz_platform.BL.ViewModels.Questions
{
    public class QuestionEditVM
    {
        public int Id { get; set; } 
        [Required]
        public string QuestionText { get; set; } = string.Empty;
        [Required]
        public string AnswerType { get; set; } = string.Empty;
        [Required]
        [DisplayName("Quiz Name")]
        public int QuizId { get; set; }


        public QuestionEditVM()
        {

        }
        public QuestionEditVM(int id, string questionText, string answerType, int quizId)
        {
            Id = id;
            QuestionText = questionText;
            AnswerType= answerType;
            QuizId = quizId;     
        }
    }
}
