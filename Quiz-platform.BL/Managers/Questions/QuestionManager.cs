using Quiz_platform.BL.ViewModels;
using Quiz_platform.BL.ViewModels.Questions;
using Quiz_platform.BL.ViewModels.Quizzes;
using Quiz_platform.DAL.Data.Models;
using Quiz_platform.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            var question = _unitOfWork.QuestionRepository.GetbyId(id); 
            if (question is null)
                return;

            _unitOfWork.QuestionRepository.Delete(question);  
            _unitOfWork.SaveChanges();
        }

        public void Edit(QuestionEditVM questionEditVM)
        {
           
            var question = _unitOfWork.QuestionRepository.GetbyId(questionEditVM.Id);  
            if (question is null)
                return;
            question.QuestionText = questionEditVM.QuestionText; 
            question.AnswerType = questionEditVM.AnswerType;   
            question.QuizId= questionEditVM.QuizId;  
            _unitOfWork.QuestionRepository.Update(question);  
            _unitOfWork.SaveChanges();  
        }

        public IEnumerable<QuestionReadVM> GetAll()
        {
            IEnumerable<Question> questions = _unitOfWork.QuestionRepository.GetAll();

            IEnumerable<QuestionReadVM> questionsVM =  questions
                .Select(q => new QuestionReadVM(q.Id, q.QuestionText, q.AnswerType, q.QuizId));

            return questionsVM;
        }

        public QuestionEditVM? GetForEditById(int id)
        {
            var question = _unitOfWork.QuestionRepository.GetbyId(id);
            if (question is null)
                return null;

            return new QuestionEditVM(question.Id,
                question.QuestionText,
                question.AnswerType,
                question.QuizId);
        }

        public IEnumerable<Option> GetAllAsOptions()
        {
            return _unitOfWork.QuestionRepository
                 .GetAll()
                 .Select(q => new Option(q.QuestionText, q.Id.ToString()));
        }


    }
}
