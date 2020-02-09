namespace Dispatcher.Repository.EF.Context
{
    using Entity.Entities;
    using System.Data.Entity;

    public partial class EFDbContext : DbContext
    {
        public EFDbContext() : base("name=dbConnectionString") { }

        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<Week> Weeks { get; set; }
        public virtual DbSet<Hour> Hours { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<TeacherInfo> TeacherInfos { get; set; }
        public virtual DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public virtual DbSet<GroupLessonPair> GroupLessonPairs { get; set; }
        public virtual DbSet<ExamRoomRegister> ExamRoomRegisters { get; set; }
        public virtual DbSet<LessonRoomRegister> LessonRoomRegisters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AcademicDegree>()
                .HasMany(e => e.Teachers)
                .WithMany(e => e.AcademicDegrees)
                .Map(m => m.ToTable("TEACHERS_DEGREES").MapLeftKey("ACADEMIC_DEGREE_ID").MapRightKey("TEACHER_ID"));

            modelBuilder.Entity<Building>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Building)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoomType>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.RoomType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hour>()
                .HasMany(e => e.LessonRoomRegisters)
                .WithRequired(e => e.Hour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hour>()
                .HasMany(e => e.TeacherInfos)
                .WithRequired(e => e.CounselHour)
                .HasForeignKey(e => e.CounselHourId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lesson>()
                .HasMany(e => e.LessonRoomRegisters)
                .WithRequired(e => e.Lesson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lesson>()
                .HasMany(e => e.Teachers)
                .WithMany(e => e.Lessons)
                .Map(m => m.ToTable("TEACHERS_LESSONS").MapLeftKey("LESSON_ID").MapRightKey("TEACHER_ID"));

            modelBuilder.Entity<Room>()
                .Property(e => e.Name);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.LessonRoomRegisters)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Room>()
            //    .HasMany(e => e.TEACHERS_INFOS)
            //    .WithRequired(e => e.CounselRoom)
            //    .HasForeignKey(e => e.CounselRoomId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Room>()
            //    .HasMany(e => e.TEACHERS_INFOS1)
            //    .WithRequired(e => e.LectureRoom)
            //    .HasForeignKey(e => e.LectureRoomId)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.LessonRoomRegisters)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.TeacherInfos)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Day>()
                .HasMany(e => e.LessonRoomRegisters)
                .WithRequired(e => e.Day)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Week>()
                .HasMany(e => e.LessonRoomRegisters)
                .WithRequired(e => e.Week)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.LessonRoomRegisters)
                .WithMany(e => e.Groups)
                .Map(m => m.ToTable("LESSON_ROOM_REGISTERS_GROUPS").MapLeftKey("GROUP_ID").MapRightKey("LESSON_ROOM_REGISTER_ID"));



            modelBuilder.Entity<ExamRoomRegister>()
                .HasMany(e => e.GroupLessonPairs)
                .WithRequired(e => e.ExamRoomRegister)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExamRoomRegister>()
                .HasMany(e => e.Supervisiors)
                .WithMany(e => e.ExamRoomRegisters)
                .Map(m => m.ToTable("EXAM_ROOM_REGISTERS_SUPERVISIORS").MapLeftKey("EXAM_ROOM_REGISTER_ID").MapRightKey("TEACHER_ID"));


            modelBuilder.Entity<Hour>()
                .HasMany(e => e.ExamRoomRegisters)
                .WithRequired(e => e.Hour)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupLessonPair)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);


            //modelBuilder.Entity<Lesson>()
            //    .HasMany(e => e.GroupLessonPairs)
            //    .WithRequired(e => e.Lesson)
            //    .WillCascadeOnDelete(false);



            modelBuilder.Entity<Room>()
                .HasMany(e => e.ExamRoomRegisters)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);
        }
    }
}
