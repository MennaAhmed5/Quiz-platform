using Quiz_platform.BL.ViewModels.Questions;
using Quiz_platform.BL.ViewModels.Quizzes;
using Quiz_platform.DAL.Data.Models;
using Quiz_platform.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.BL.Managers.Questions
{
    public class QuestionManager : IQuestionManager
    {

        private readonly IUnitOfWork _unitOfWork;
        public QuestionManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(QuestionAddVM questionAddVM)
        {
            var question = new Question
            {
                QuestionText = questionAddVM.QuestionText,
                AnswerType = questionAddVM.AnswerType,
                QuizId = questionAddVM.QuizId,
                
            };

            _unitOfWork.QuestionRepository.Add(question);
            _unitOfWork.SaveChanges();
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(QuestionEditVM questionEditVM)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QuestionReadVM> GetAll()
        {
            throw new NotImplementedException();
        }

        public QuestionEditVM? GetForEditById(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
