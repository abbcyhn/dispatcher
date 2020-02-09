namespace Dispatcher.WebUI.Controllers
{
    using Helpers;
    using System.Linq;
    using System.Web.Mvc;
    using UnitOfWorkPattern;
    using Models.ExamRoomRegister;

    public class ExamRoomRegisterController : Controller
    {
        private IUnitOfWork uow;

        public ExamRoomRegisterController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var registers = uow.ExamRoomRegisters.SelectAll().ToList();
            return View(registers);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new ERRegisterAddOrEditModel(uow, Url.Action("Add"));
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Add(ERRegisterModel lrModel)
        {
            var inserted = lrModel.ToEntity();

            uow.ExamRoomRegisters.Insert(inserted);
            uow.SaveChanges();

            var viewModel = new ERRegisterAddOrEditModel(uow, Url.Action("Edit"), inserted.Id);
            return View("AddOrEdit", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new ERRegisterAddOrEditModel(uow, Url.Action("Edit"), id);
            return View("AddOrEdit", model);
        }

        [HttpPost]
        public ActionResult Edit(ERRegisterModel lrModel)
        {
            var updated = lrModel.ToEntity();

            uow.ExamRoomRegisters.Update(updated);
            uow.SaveChanges();

            var viewModel = new ERRegisterAddOrEditModel(uow, Url.Action("Edit"), updated.Id);
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var deleted = uow.ExamRoomRegisters.SelectById(id);
            if (deleted != null)
            {
                uow.ExamRoomRegisters.Delete(deleted);
                uow.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}