using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.DAL.Data.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        public string OptionText { get; set; } = string.Empty;
        [Required]
        public bool IsCorrect { get; set; }
        [Required]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; } = null!;
    }
}
