using Quiz_platform.BL.ViewModels.Answers;
using Quiz_platform.BL.ViewModels.Questions;
using Quiz_platform.DAL.Data.Models;
using Quiz_platform.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.BL.Managers.Answers
{
    public class AnwserManager : IAnswerManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnwserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(AnswerAddVM answerAddVM)
        {
            var answer = new Answer
            {
                OptionText = answerAddVM.OptionText,
                IsCorrect = answerAddVM.IsCorrect,
                QuestionId = answerAddVM.QuestionId,

            };

            _unitOfWork.AnswerRepository.Add(answer);
            _unitOfWork.SaveChanges();

        }

        public void Delete(int id)
        {
            var answer = _unitOfWork.AnswerRepository.GetbyId(id);
            if (answer is null)
                return;

            _unitOfWork.AnswerRepository.Delete(answer);
            _unitOfWork.SaveChanges();
        }

        public void Edit(AnswerEditVM answerEditVM)
        {
            var answer = _unitOfWork.AnswerRepository.GetbyId(answerEditVM.Id);
            if (answer is null)
                return;
            answer.OptionText = answerEditVM.OptionText;
            answer.IsCorrect = answerEditVM.IsCorrect;
            answer.QuestionId = answerEditVM.QuestionId;
            _unitOfWork.AnswerRepository.Update(answer);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<AnswerReadVM> GetAll()
        {
            IEnumerable<Answer> Answers = _unitOfWork.AnswerRepository.GetAll();

            IEnumerable<AnswerReadVM> answersVM = Answers
                .Select(a=> new AnswerReadVM(a.Id, a.OptionText, a.IsCorrect, a.QuestionId));

            return answersVM;
        }

        public AnswerEditVM? GetForEditById(int id)
        {
            var answer = _unitOfWork.AnswerRepository.GetbyId(id);
            if (answer is null)
                return null;

            return new AnswerEditVM(answer.Id,
                answer.OptionText,
                answer.IsCorrect,
                answer.QuestionId);
        }
    }
}
