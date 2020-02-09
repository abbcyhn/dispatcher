namespace Dispatcher.WebUI.Controllers
{
    using Helpers;
    using System.Linq;
    using Models.Lesson;
    using System.Web.Mvc;
    using Entity.Entities;
    using UnitOfWorkPattern;

    public class LessonController : Controller
    {
        private IUnitOfWork uow;

        public LessonController(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var lessons = uow.Lessons.SelectAll().ToList();
            return View(lessons);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new LessonAddOrEditModel(uow, Url.Action("Add"));
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Add(LessonModel lessonModel)
        {
            Lesson inserted = lessonModel.ToEntity();

            uow.Lessons.Insert(inserted);
            uow.SaveChanges();

            var viewModel = new LessonAddOrEditModel(uow, Url.Action("Edit"), inserted.Id);
            return View("AddOrEdit", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = new LessonAddOrEditModel(uow, Url.Action("Edit"), id);
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(LessonModel lessonModel)
        {
            var updated = lessonModel.ToEntity();

            uow.Lessons.Update(updated);
            uow.SaveChanges();

            var viewModel = new LessonAddOrEditModel(uow, Url.Action("Edit"), updated.Id);
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var deleted = uow.Lessons.SelectById(id);
            if (deleted != null)
            {
                uow.Lessons.Delete(deleted);
                uow.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}