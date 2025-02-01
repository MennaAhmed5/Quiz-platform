using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quiz_platform.BL.Managers.Quizes;
using Quiz_platform.BL.Managers.Quizzes;
using Quiz_platform.BL.ViewModels.Quizzes;
using Quiz_platform.DAL.UnitOfWork;

namespace Quiz_platform.Controllers
{
    public class QuizzesController : Controller
    {
        private readonly IQuizManager _quizManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        public QuizzesController(IQuizManager quizManager, IWebHostEnvironment webHostEnvironment, IUnitOfWork unitOfWork)
        {
            _quizManager = quizManager;
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var quizzes = _quizManager.GetAll();
            return View(quizzes);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(QuizAddVM quizAddVM, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                _quizManager.Add(quizAddVM);
                return RedirectToAction(nameof(Index));                
            }

            return View(quizAddVM);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var doctorEditVM = _quizManager.GetForEditById(id);
            return View(doctorEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(QuizEditVM quizEditVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string rootPath = _webHostEnvironment.WebRootPath; //wwwroot folder
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString();
                    var Upload = Path.Combine(rootPath, @"Images\Quizzes");
                    var ext = Path.GetExtension(file.FileName);

                    if (quizEditVM.Image != null)
                    {
                        var olding = Path.Combine(rootPath, quizEditVM.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(olding))
                        {
                            System.IO.File.Delete(olding);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(Upload, filename + ext), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    quizEditVM.Image = @"Images\Quizzes\" + filename + ext;
                }
                _quizManager.Edit(quizEditVM);
                return RedirectToAction(nameof(Index));

            }
            return View(quizEditVM);
        }

        
        public IActionResult Delete(int id)
        {
            var quiz = _unitOfWork.QuizRepository.GetbyId(id);
            if (quiz == null)
            {
                return NotFound();
            }

            _unitOfWork.QuizRepository.Delete(quiz);
            var olding = Path.Combine(_webHostEnvironment.WebRootPath, quiz.Image.TrimStart('\\'));
            if (System.IO.File.Exists(olding))
            {
                System.IO.File.Delete(olding);
            }
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
