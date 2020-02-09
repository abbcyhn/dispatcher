namespace Dispatcher.WebUI.Models.Teacher
{
    using Shared;
    using Entity.Entities;
    using UnitOfWorkPattern;
    using System.Collections.Generic;

    public class TeacherAddOrEditModel : AddOrEditViewModel
    {
        public TeacherAddOrEditModel(IUnitOfWork uow, string postUrl, int teacherId = 0) : base(uow, postUrl, teacherId) { }


        public Teacher Teacher
        {
            get { return Uow.Teachers.SelectById(EntityId) ?? new Teacher(); }
        }
        public IEnumerable<GenericViewModel<Room>> LectureRoomModels
        {
            get
            {
                var selectedRooms = new List<Room>();

                foreach (var ti in Teacher.TeacherInfos)
                    selectedRooms.Add(ti.LectureRoom);

                return GenericModelCreator.GetGenericModel(Rooms, selectedRooms);
            }
        }
        public IEnumerable<GenericViewModel<Room>> CounselRoomModels
        {
            get
            {
                var selectedRooms = new List<Room>();

                foreach (var ti in Teacher.TeacherInfos)
                    selectedRooms.Add(ti.CounselRoom);

                return GenericModelCreator.GetGenericModel(Rooms, selectedRooms);
            }
        }
        public IEnumerable<GenericViewModel<Hour>> CounselHourModels
        {
            get
            {
                var hours = Uow.Hours.SelectAllCounselHour();
                var selectedHours = new List<Hour>();

                foreach (var ti in Teacher.TeacherInfos)
                    selectedHours.Add(ti.CounselHour);

                return GenericModelCreator.GetGenericModel(hours, selectedHours);
            }
        }
        public IEnumerable<GenericViewModel<AcademicDegree>> AcademicDegreeModels
        {
            get
            {
                var allDegrees = Uow.AcademicDegrees.SelectAll();
                var selectedDegrees = Teacher?.AcademicDegrees;

                return GenericModelCreator.GetGenericModel(allDegrees, selectedDegrees);
            }
        }


        private IEnumerable<Room> Rooms { get { return Uow.Rooms.SelectAll(); } }
    }
}