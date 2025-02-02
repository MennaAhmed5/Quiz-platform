using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz_platform.BL.Managers.Answers;
using Quiz_platform.BL.Managers.Questions;
using Quiz_platform.BL.Managers.Quizes;
using Quiz_platform.BL.Managers.Quizzes;
using Quiz_platform.BL.ViewModels.Answers;
using Quiz_platform.BL.ViewModels.Questions;
using Quiz_platform.DAL.UnitOfWork;

namespace Quiz_platform.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    public class AnswersController : Controller
    {

        private readonly IAnswerManager _answerManager;
        public readonly IQuestionManager _questionManager;
        public AnswersController(IAnswerManager answerManager, IQuestionManager questionManager)
        {
            _answerManager = answerManager;
            _questionManager = questionManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
             
            return View();
        }

        public IActionResult GetData()
        {
            var answers = _answerManager.GetAll();
            return Json(new { data= answers });
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Questions"] = _questionManager.GetAllAsOptions()
                 .Select(o => new SelectListItem(o.Name, o.Value));
            return View();
        }

        [HttpPost]
        public IActionResult Add(AnswerAddVM answerAddVM)
        {
            if (ModelState.IsValid)
            {
                _answerManager.Add(answerAddVM);
                return RedirectToAction(nameof(Index));
            }

            return View(answerAddVM);
          
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var answerEditVM = _answerManager.GetForEditById(id);
            if (answerEditVM == null)
                return NotFound();
            ViewData["Questions"] = _questionManager.GetAllAsOptions()
               .Select(o => new SelectListItem(o.Name, o.Value));
            return View(answerEditVM);
        }

        [HttpPost]
        public IActionResult Edit(AnswerEditVM answerEditVM)
        {
            if(ModelState.IsValid)
            {
                _answerManager.Edit(answerEditVM);
                return RedirectToAction(nameof(Index));
            }

            return View(answerEditVM);

        }
        public IActionResult Delete(int id)
        {
            _answerManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
