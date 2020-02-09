namespace Dispatcher.Repository.EF.UnitOfWork
{
    using Context;
    using Repositories;
    using RepositoryPattern;
    using UnitOfWorkPattern;

    public class EFUnitOfWork : IUnitOfWork
    {
        private EFDbContext ctx = new EFDbContext();

        private static IDayRepository dayRepo;
        private static IWeekRepository weekRepo;
        private static IRoomRepository roomRepo;
        private static IHourRepository hourRepo;
        private static IGroupRepository groupRepo;
        private static ILessonRepository lessonRepo;
        private static ICourseRepository courseRepo;
        private static IStudentRepository studentRepo;
        private static ITeacherRepository teacherRepo;
        private static IBuildingRepository buildingRepo;
        private static IRoomTypeRepository roomTypeRepo;
        private static IAcademicDegreeRepository academicDegreeRepo;
        private static IExamRoomRegisterRepository examRegisterRepo;
        private static ILessonRoomRegisterRepository lessonRegisterRepo;

        public IDayRepository Days
        {
            get
            {
                if (dayRepo == null)
                    dayRepo = new DayRepository(ctx);
                return dayRepo;
            }
        }
        public IWeekRepository Weeks
        {
            get
            {
                if (weekRepo == null)
                    weekRepo = new WeekRepository(ctx);
                return weekRepo;
            }
        }
        public IRoomRepository Rooms
        {
            get
            {
                if(roomRepo == null)
                    roomRepo = new RoomRepository(ctx);
                return roomRepo;
            }
        }
        public IHourRepository Hours
        {
            get
            {
                if (hourRepo == null)
                    hourRepo = new HourRepository(ctx);
                return hourRepo;
            }
        }
        public IGroupRepository Groups
        {
            get
            {
                if (groupRepo == null)
                    groupRepo = new GroupRepository(ctx);
                return groupRepo;
            }
        }
        public ILessonRepository Lessons
        {
            get
            {
                if (lessonRepo == null)
                    lessonRepo = new LessonRepository(ctx);
                return lessonRepo;
            }
        }
        public ICourseRepository Courses
        {
            get
            {
                if (courseRepo == null)
                    courseRepo = new CourseRepository(ctx);
                return courseRepo;
            }
        }
        public IStudentRepository Students
        {
            get
            {
                if (studentRepo == null)
                    studentRepo = new StudentRepository(ctx);
                return studentRepo;
            }
        }
        public ITeacherRepository Teachers
        {
            get
            {
                if (teacherRepo == null)
                    teacherRepo = new TeacherRepository(ctx);
                return teacherRepo;
            }
        }
        public IBuildingRepository Buildings
        {
            get
            {
                if (buildingRepo == null)
                    buildingRepo = new BuildingRepository(ctx);
                return buildingRepo;
            }
        }
        public IRoomTypeRepository RoomTypes
        {
            get
            {
                if (roomTypeRepo == null)
                    roomTypeRepo = new RoomTypeRepository(ctx);
                return roomTypeRepo;
            }
        }
        public IAcademicDegreeRepository AcademicDegrees
        {
            get
            {
                if (academicDegreeRepo == null)
                    academicDegreeRepo = new AcademicDegreeRepository(ctx);
                return academicDegreeRepo;
            }
        }
        public IExamRoomRegisterRepository ExamRoomRegisters
        {
            get
            {
                if (examRegisterRepo == null)
                    examRegisterRepo = new ExamRoomRegisterRepository(ctx);
                return examRegisterRepo;
            }
        }
        public ILessonRoomRegisterRepository LessonRoomRegisters
        {
            get
            {
                if (lessonRegisterRepo == null)
                    lessonRegisterRepo = new LessonRoomRegisterRepository(ctx);
                return lessonRegisterRepo;
            }
        }

        public void Dispose()
        {
            if (ctx != null)
                ctx.Dispose();
        }
        public void SaveChanges()
        {
            ctx.SaveChanges();
        }
    }
}