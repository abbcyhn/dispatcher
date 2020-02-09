namespace Dispatcher.WebUI.Controllers
{
    using Helpers;
    using System.Linq;
    using Models.Student;
    using System.Web.Mvc;
    using UnitOfWorkPattern;

    public class StudentController : Controller
    {
        private IUnitOfWork uow;

        public StudentController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var students = uow.Students.SelectAll().ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentAddOrEditModel(uow, Url.Action("Add"));
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentModel studentModel)
        {
            var inserted = studentModel.ToEntity();

            uow.Students.Insert(inserted);
            uow.SaveChanges();

            var viewModel = new StudentAddOrEditModel(uow, Url.Action("Edit"), inserted.Id);
            return View("AddOrEdit", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = new StudentAddOrEditModel(uow, Url.Action("Edit"), id);
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentModel studentModel)
        {
            var updated = studentModel.ToEntity();

            uow.Students.Update(updated);
            uow.SaveChanges();

            var viewModel = new StudentAddOrEditModel(uow, Url.Action("Edit"), updated.Id);
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var deleted = uow.Students.SelectById(id);
            if (deleted != null)
            {
                uow.Students.Delete(deleted);
                uow.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}