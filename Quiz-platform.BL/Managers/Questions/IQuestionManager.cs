using Quiz_platform.BL.ViewModels;
using Quiz_platform.BL.ViewModels.Questions;
using Quiz_platform.BL.ViewModels.Quizzes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.BL.Managers.Questions
{
    public interface IQuestionManager
    {
        IEnumerable<QuestionReadVM> GetAll();
        QuestionEditVM? GetForEditById(int id);
        void Add(QuestionAddVM questionAddVM);
        void Edit(QuestionEditVM questionEditVM);
        void Delete(int id);
        public IEnumerable<Option> GetAllAsOptions();
    }
}
