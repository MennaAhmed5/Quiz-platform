﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.DAL.Data.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string QuestionText { get; set; } = string.Empty;
        [Required]
        public string AnswerType { get; set; } = string.Empty;
        [Required]
        public int QuizId { get; set; }
        public  virtual Quiz Quiz { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; } = [];
    }

}
