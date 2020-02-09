namespace Dispatcher.WebUI.Controllers
{
    using System;
    using Helpers;
    using System.Linq;
    using System.Web.Mvc;
    using UnitOfWorkPattern;
    using Models.LessonRoomRegister;

    public class LessonRoomRegisterController : Controller
    {
        private IUnitOfWork uow;

        public LessonRoomRegisterController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var registers = uow.LessonRoomRegisters.SelectAll().ToList();
            return View(registers);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new LRRegisterAddOrEditModel(uow, Url.Action("Add"));
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Add(LRRegisterModel lrModel)
        {
            var inserted = lrModel.ToEntity();

            uow.LessonRoomRegisters.Insert(inserted);
            uow.SaveChanges();

            var viewModel = new LRRegisterAddOrEditModel(uow, Url.Action("Edit"), inserted.Id);
            return View("AddOrEdit", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new LRRegisterAddOrEditModel(uow, Url.Action("Edit"), id);
            return View("AddOrEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(LRRegisterModel lrModel)
        {
            var updated = lrModel.ToEntity();

            uow.LessonRoomRegisters.Update(updated);
            uow.SaveChanges();

            var viewModel = new LRRegisterAddOrEditModel(uow, Url.Action("Edit"), updated.Id);
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var deleted = uow.LessonRoomRegisters.SelectById(id);
            if (deleted != null)
            {
                uow.LessonRoomRegisters.Delete(deleted);
                uow.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}