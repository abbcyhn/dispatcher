namespace Dispatcher.WebUI.Controllers
{
    using Helpers;
    using System.Linq;
    using Models.Teacher;
    using System.Web.Mvc;
    using Entity.Entities;
    using UnitOfWorkPattern;

    public class TeacherController : Controller
    {
        private IUnitOfWork uow;

        public TeacherController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var teachers = uow.Teachers.SelectAll().ToList();
            return View(teachers);
        }


        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new TeacherAddOrEditModel(uow, Url.Action("Add"));
            return View("AddOrEdit", viewModel);
        }


        [HttpPost]
        public ActionResult Add(TeacherModel teacherModel)
        {
            var inserted = teacherModel.ToEntity();

            uow.Teachers.Insert(inserted);
            uow.SaveChanges();

            var viewModel = new TeacherAddOrEditModel(uow, Url.Action("Edit"), inserted.Id);
            return View("AddOrEdit", viewModel);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = new TeacherAddOrEditModel(uow, Url.Action("Edit"), id);
            return View("AddOrEdit", viewModel);
        }


        [HttpPost]
        public ActionResult Edit(TeacherModel teacherModel)
        {
            var updated = teacherModel.ToEntity();

            uow.Teachers.Update(updated);
            uow.SaveChanges();

            var viewModel = new TeacherAddOrEditModel(uow, Url.Action("Edit"), updated.Id);
            return View("AddOrEdit", viewModel);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var deleted = uow.Teachers.SelectById(id);
            if (deleted != null)
            {
                uow.Teachers.Delete(deleted);
                uow.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}