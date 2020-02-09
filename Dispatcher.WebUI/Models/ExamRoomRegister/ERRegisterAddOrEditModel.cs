namespace Dispatcher.WebUI.Models.ExamRoomRegister
{
    using Shared;
    using Entity.Entities;
    using UnitOfWorkPattern;
    using System.Collections.Generic;

    public class ERRegisterAddOrEditModel : AddOrEditViewModel
    {
        public ERRegisterAddOrEditModel(IUnitOfWork uow, string postUrl, int entityId = 0) : base(uow, postUrl, entityId) { }

        public ExamRoomRegister ERRegister
        {
            get { return Uow.ExamRoomRegisters.SelectById(EntityId) ?? new ExamRoomRegister(); }
        }
        public string ExamDate => ERRegister.ExamDate?.ToString("dd-MM-yyyy");
        public IEnumerable<GenericViewModel<Room>> RoomModels
        {
            get
            {
                var allRooms = Uow.Rooms.SelectAll();
                var selectedRoom = new List<Room>() { ERRegister.Room };

                return GenericModelCreator.GetGenericModel(allRooms, selectedRoom);
            }
        }
        public IEnumerable<GenericViewModel<Hour>> HourModels
        {
            get
            {
                var allHours = Uow.Hours.SelectAllExamHour();
                var selectedHour = new List<Hour>() { ERRegister.Hour };

                return GenericModelCreator.GetGenericModel(allHours, selectedHour);
            }
        }
        public IEnumerable<GenericViewModel<Group>> GroupModels
        {
            get
            {
                var allGroups = Uow.Groups.SelectAll();
                var selectedGroups = new List<Group>();

                foreach (var pair in ERRegister.GroupLessonPairs)
                    selectedGroups.Add(pair.Group);

                return GenericModelCreator.GetGenericModel(allGroups, selectedGroups);
            }
        }
        public IEnumerable<GenericViewModel<Lesson>> LessonModels
        {
            get
            {
                var allLessons = Uow.Lessons.SelectAll();
                var selectedLessons = new List<Lesson>();

                foreach (var pair in ERRegister.GroupLessonPairs)
                    selectedLessons.Add(pair.Lesson);

                return GenericModelCreator.GetGenericModel(allLessons, selectedLessons);
            }
        }
        public IEnumerable<GenericViewModel<Teacher>> SupervisiorModels
        {
            get
            {
                var allSupervisior = Uow.Teachers.SelectAll();
                var selectedSuperivisior = ERRegister.Supervisiors;

                return GenericModelCreator.GetGenericModel(allSupervisior, selectedSuperivisior);
            }
        }
    }
}