using Quiz_platform.DAL.Repositories.Answers;
using Quiz_platform.DAL.Repositories.Questions;
using Quiz_platform.DAL.Repositories.Quizzes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IQuizRepository QuizRepository { get; }

        public IQuestionRepository QuestionRepository { get; }

        public IAnswerRepository AnswerRepository { get; }
        void SaveChanges();
    }
}
