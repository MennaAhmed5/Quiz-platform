using Quiz_platform.BL.ViewModels.Quizzes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.BL.Managers.Quizzes
{
    public interface IQuizManager
    {
        IEnumerable<QuizReadVM> GetAll();
        QuizDetailsVM? GetDetailsById(int id);

        QuizEditVM? GetForEditById(int id);
        void Add(QuizAddVM quizAddVM);
        void Edit(QuizEditVM quizEditVM);

        //void Delete(int id);
    }
}
