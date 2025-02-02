using Quiz_platform.BL.ViewModels.Answers;
using Quiz_platform.BL.ViewModels.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_platform.BL.Managers.Answers
{
    public interface IAnswerManager
    {
        IEnumerable<AnswerReadVM> GetAll();
        AnswerEditVM? GetForEditById(int id);
        void Add(AnswerAddVM answerAddVM);
        void Edit(AnswerEditVM answerEditVM);
        void Delete(int id);
    }
}
