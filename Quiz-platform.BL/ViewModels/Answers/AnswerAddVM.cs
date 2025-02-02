using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Quiz_platform.BL.ViewModels.Answers
{
    public class AnswerAddVM
    {
        public string OptionText { get; set; } = string.Empty;
        [Required]
        public bool IsCorrect { get; set; }
        [Required]
        [DisplayName("Question Name")]
        public int QuestionId { get; set; }

    }
}
