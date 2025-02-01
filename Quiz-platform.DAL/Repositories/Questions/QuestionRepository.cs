using Quiz_platform.DAL.Data.Context;
using Quiz_platform.DAL.Data.Models;
using Quiz_platform.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.DAL.Repositories.Questions
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(QuizContext context) : base(context)
        {

        }
    }
}
