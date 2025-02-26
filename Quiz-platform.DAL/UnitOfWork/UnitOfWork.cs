﻿using Quiz_platform.DAL.Data.Context;
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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizContext _context;
        public IQuizRepository QuizRepository { get; }
        public IQuestionRepository QuestionRepository { get; }
        public IAnswerRepository AnswerRepository { get; }
        public UnitOfWork(QuizContext context, IQuizRepository quizRepository, IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            _context = context;
            QuizRepository = quizRepository;
            QuestionRepository = questionRepository;
            AnswerRepository =answerRepository;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
