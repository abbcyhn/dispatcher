namespace Dispatcher.WebUI.Models.LessonRoomRegister
{
    using Shared;
    using Entity.Entities;
    using UnitOfWorkPattern;
    using System.Collections.Generic;

    public class LRRegisterAddOrEditModel : AddOrEditViewModel
    {
        public LRRegisterAddOrEditModel(IUnitOfWork uow, string postUrl, int entityId = 0) : base(uow, postUrl, entityId) { }

        public LessonRoomRegister LRRegister
        {
            get { return Uow.LessonRoomRegisters.SelectById(EntityId) ?? new LessonRoomRegister(); }
        }
        public IEnumerable<GenericViewModel<Group>> GroupModels
        {
            get
            {
                var allGroups = Uow.Groups.SelectAll();
                var selectedGroup = LRRegister.Groups;

                return GenericModelCreator.GetGenericModel(allGroups, selectedGroup);
            }
        }
        public IEnumerable<GenericViewModel<Lesson>> LessonModels
        {
            get
            {
                var allLessons = Uow.Lessons.SelectAll();
                var selectedLesson = new List<Lesson> { LRRegister.Lesson };

                return GenericModelCreator.GetGenericModel(allLessons, selectedLesson);
            }
        }
        public IEnumerable<GenericViewModel<Teacher>> TeacherModels
        {
            get
            {
                var allTeachers = Uow.Teachers.SelectAll();
                var selectedTeacher = new List<Teacher> { LRRegister.Teacher };

                return GenericModelCreator.GetGenericModel(allTeachers, selectedTeacher);
            }
        }
        public IEnumerable<GenericViewModel<Room>> RoomModels
        {
            get
            {
                var allRooms = Uow.Rooms.SelectAll();
                var selectedRoom = new List<Room> { LRRegister.Room };

                return GenericModelCreator.GetGenericModel(allRooms, selectedRoom);
            }
        }
        public IEnumerable<GenericViewModel<Week>> WeekModels
        {
            get
            {
                var allWeeks = Uow.Weeks.SelectAll();
                var selectedWeek = new List<Week> { LRRegister.Week };

                return GenericModelCreator.GetGenericModel(allWeeks, selectedWeek);
            }
        }
        public IEnumerable<GenericViewModel<Day>> DayModels
        {
            get
            {
                var allDays = Uow.Days.SelectOnlyLessonDays();
                var selectedDay = new List<Day> { LRRegister.Day };

                return GenericModelCreator.GetGenericModel(allDays, selectedDay);
            }
        }
        public IEnumerable<GenericViewModel<Hour>> HourModels
        {
            get
            {
                var allHours = Uow.Hours.SelectAllLessonHour();
                var selectedHour = new List<Hour> { LRRegister.Hour };

                return GenericModelCreator.GetGenericModel(allHours, selectedHour);
            }
        }
    }
}