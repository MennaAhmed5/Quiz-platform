using Quiz_platform.DAL.Data.Context;
using Quiz_platform.DAL.Data.Models;
using Quiz_platform.DAL.Repositories.Generic;
using Quiz_platform.DAL.Repositories.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.DAL.Repositories.Answers
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(QuizContext context) : base(context)
        {
        }
    }
}
