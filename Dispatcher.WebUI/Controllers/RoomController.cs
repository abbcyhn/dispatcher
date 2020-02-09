namespace Dispatcher.WebUI.Controllers
{
    using Helpers;
    using Models.Room;
    using System.Linq;
    using System.Web.Mvc;
    using UnitOfWorkPattern;

    public class RoomController : Controller
    {
        private IUnitOfWork uow;

        public RoomController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var rooms = uow.Rooms.SelectAll().ToList();
            return View(rooms);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new RoomAddOrEditModel(uow, Url.Action("Add"));
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Add(RoomModel roomModel)
        {
            var inserted = roomModel.ToEntity();

            uow.Rooms.Insert(inserted);
            uow.SaveChanges();

            var viewModel = new RoomAddOrEditModel(uow, Url.Action("Edit"), inserted.Id);
            return View("AddOrEdit", viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = new RoomAddOrEditModel(uow, Url.Action("Edit"), id);
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(RoomModel roomModel)
        {
            var updated = roomModel.ToEntity();

            uow.Rooms.Update(updated);
            uow.SaveChanges();

            var viewModel = new RoomAddOrEditModel(uow, Url.Action("Edit"), updated.Id);
            return View("AddOrEdit", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var deleted = uow.Rooms.SelectById(id);
            if (deleted != null)
            {
                uow.Rooms.Delete(deleted);
                uow.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}