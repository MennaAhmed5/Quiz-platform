using Quiz_platform.BL.Managers.Quizzes;
using Quiz_platform.BL.ViewModels.Quizzes;
using Quiz_platform.DAL.Data.Models;
using Quiz_platform.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.BL.Managers.Quizes
{
    public class QuizManager : IQuizManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuizManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(QuizAddVM quizAddVM)
        {
            var quiz = new Quiz
            {
                Name = quizAddVM.Name,
                Description = quizAddVM.Description,
                Image = quizAddVM.Image,
                Date = quizAddVM.Date

            };

            _unitOfWork.QuizRepository.Add(quiz);
            _unitOfWork.SaveChanges();
            
        }

       /*public void Delete(int id)
        {
            var quiz = _unitOfWork.QuizRepository.GetbyId(id);  
            if (quiz is null)
                return;

            _unitOfWork.QuizRepository.Delete(quiz);  
            _unitOfWork.SaveChanges(); 
        }*/

        public void Edit(QuizEditVM quizEditVM)
        {
           
            var quiz = _unitOfWork.QuizRepository.GetbyId(quizEditVM.Id); 
            if (quiz is null)
                return;
            quiz.Name = quizEditVM.Name;
            quiz.Image = quizEditVM.Image;
            quiz.Description = quizEditVM.Description;  
            quiz.Date = quizEditVM.Date;
            _unitOfWork.QuizRepository.Update(quiz);  
            _unitOfWork.SaveChanges(); 
        }

        public IEnumerable<QuizReadVM> GetAll()
        {
            IEnumerable<Quiz> quizzes = _unitOfWork.QuizRepository.GetAll();

            IEnumerable<QuizReadVM> quizzesVM = quizzes
                .Select(q => new QuizReadVM(q.Id, q.Name,q.Description,q.Date));

            return quizzesVM;
        }

        public QuizDetailsVM? GetDetailsById(int id)
        {
            throw new NotImplementedException();
        }

  

        public QuizEditVM? GetForEditById(int id)
        {
            var quiz = _unitOfWork.QuizRepository.GetbyId(id);
            if (quiz is null)
                return null;

            return new QuizEditVM(quiz.Id,
                quiz.Name,
                quiz.Description,
                quiz.Image,
                quiz.Date
                );
        }
    }
}
