using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz_platform.BL.Managers.Questions;
using Quiz_platform.BL.Managers.Quizzes;
using Quiz_platform.BL.ViewModels.Questions;
using Quiz_platform.BL.ViewModels.Quizzes;

namespace Quiz_platform.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    public class QuestionsController : Controller
    {
        public readonly IQuestionManager _questionManager;
        public readonly IQuizManager _quizManager;
        public QuestionsController(IQuestionManager questionManager, IQuizManager quizManager ) 
        {
            _questionManager = questionManager;
            _quizManager = quizManager;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Quizzes"] = _quizManager.GetAllAsOptions()
                  .Select(o => new SelectListItem(o.Name, o.Value));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(QuestionAddVM questionAddVM)
        {
            if (ModelState.IsValid)
            {
                _questionManager.Add(questionAddVM);
                return RedirectToAction("Index" ,"Quizzes");
            }

            return View(questionAddVM);
        }
    }
}
