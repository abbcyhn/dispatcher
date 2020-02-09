namespace Dispatcher.UnitOfWorkPattern
{
    using System;
    using RepositoryPattern;

    public interface IUnitOfWork : IDisposable
    {
        IDayRepository Days { get; }
        IWeekRepository Weeks { get; }
        IRoomRepository Rooms { get; }
        IHourRepository Hours { get; }
        IGroupRepository Groups { get; }
        ILessonRepository Lessons { get; }
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        IBuildingRepository Buildings { get; }
        IRoomTypeRepository RoomTypes { get; }
        IAcademicDegreeRepository AcademicDegrees { get; }
        IExamRoomRegisterRepository ExamRoomRegisters { get; }
        ILessonRoomRegisterRepository LessonRoomRegisters { get; }

        void SaveChanges();
    }
}