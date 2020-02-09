namespace Dispatcher.WebUI.Controllers
{
    using System.Linq;
    using Models.Group;
    using System.Web.Mvc;
    using UnitOfWorkPattern;
    using Dispatcher.WebUI.Helpers;

    public class GroupController : Controller
    {
        private IUnitOfWork uow;

        public GroupController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var groups = uow.Groups.SelectAll().ToList();
            return View(groups);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new GroupAddOrEditModel(uow, Url.Action("Add"));
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Add(GroupModel groupModel)
        {
            var inserted = groupModel.ToEntity();

            uow.Groups.Insert(inserted);
            uow.SaveChanges();

            var viewModel = new GroupAddOrEditModel(uow, Url.Action("Edit"), inserted.Id);
            return View("AddOrEdit", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = new GroupAddOrEditModel(uow, Url.Action("Edit"), id);
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(GroupModel groupModel)
        {
            var updated = groupModel.ToEntity();

            uow.Groups.Update(updated);
            uow.SaveChanges();

            var viewModel = new GroupAddOrEditModel(uow, Url.Action("Edit"), updated.Id);
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var deleted = uow.Groups.SelectById(id);
            if (deleted != null)
            {
                uow.Groups.Delete(deleted);
                uow.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}