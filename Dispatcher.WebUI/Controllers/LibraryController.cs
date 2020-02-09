namespace Dispatcher.WebUI.Controllers
{
    using Helpers;
    using Models.Shared;
    using System.Web.Mvc;
    using Entity.Entities;
    using UnitOfWorkPattern;
    using Models.ExamRoomRegister;
    using Models.LessonRoomRegister;
    using System.Collections.Generic;

    public class LibraryController : Controller
    {
        private IUnitOfWork uow;

        public LibraryController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        public ActionResult GetTeachers(string id, string name, int lessonId)
        {
            var teachers = uow.Teachers.SelectAllByLessonId(lessonId);
            var viewModel = new GenericLibraryViewModel<Teacher>
            {
                Id = id,
                Name = name,
                Models = teachers
            };

            return PartialView("Datas", viewModel);
        }

        [HttpGet]
        public ActionResult GetAvailableRooms(string id, string name, int[] groupIds)
        {
            var capacity = uow.Groups.SelectCapacity(groupIds);
            var rooms = uow.Rooms.SelectAllByCapacity(capacity);
            var viewModel = new GenericLibraryViewModel<Room>
            {
                Id = id,
                Name = name,
                Models = rooms
            };

            return PartialView("Datas", viewModel);
        }

        [HttpGet]
        public ActionResult GetAvailableGroups(string id, string name, string @class, int[] groupIds)
        {
            var groups = uow.Groups.SelectAllExceptThese(groupIds);
            var viewModel = new GenericLibraryViewModel<Group>
            {
                Id = id,
                Name = name,
                Class = @class,
                Models = groups
            };

            return PartialView("Datas", viewModel);
        }

        [HttpGet]
        public ActionResult IsRoomAndTeacherAvailableForLR(LRRegisterModel lrModel)
        {
            var lr = lrModel.ToEntity();
            var errorResults = new List<ErrorResult>();

            var lrRoom = uow.LessonRoomRegisters.SelectByRoomAndDate(lr);
            errorResults.Add(lrRoom.GetError(lrModel.Id, "Seçilən tarixdə otaq doludur!"));

            var lrTeacher = uow.LessonRoomRegisters.SelectByTeacherAndDate(lr);
            errorResults.Add(lrTeacher.GetError(lrModel.Id, "Seçilən tarixdə müəllimin dərsi var!"));

            var errorResult = errorResults.CombineErrors();
            return Json(errorResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult IsRoomAndTeacherAvailableForER(ERRegisterModel lrModel)
        {
            var lr = lrModel.ToEntity();
            var errorResults = new List<ErrorResult>();

            var lrRoom = uow.ExamRoomRegisters.SelectByRoomAndDate(lr);
            errorResults.Add(lrRoom.GetError(lrModel.Id, "Seçilən tarixdə otaq doludur!"));

            var lrSupervisior = uow.ExamRoomRegisters.SelectBySupervisiorsAndDate(lr);
            if (lrSupervisior != null)
                errorResults.Add(new ErrorResult { HasError = true, Message = "Seçilən tarixdə nəzarətçilərdən biri başqa imtahanda olacaq" });

            var errorResult = errorResults.CombineErrors();
            return Json(errorResult, JsonRequestBehavior.AllowGet);
        }
    }
}