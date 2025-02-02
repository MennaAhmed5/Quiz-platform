using Microsoft.EntityFrameworkCore;
using Quiz_platform.DAL.Data.Context;
using Quiz_platform.DAL.Data.Models;
using Quiz_platform.DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.DAL.Repositories.Quizzes
{
    public class QuizRepository : GenericRepository<Quiz>, IQuizRepository
    {
        private readonly QuizContext _context;
        public QuizRepository(QuizContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Quiz> GetAllUsingProc()
        {
           var quizzes =  _context.Quizes.FromSqlRaw("EXEC GetAllQuizes").ToList();
           return quizzes;
        }
    }
}
