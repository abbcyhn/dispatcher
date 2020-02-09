namespace Dispatcher.Entity.Entities
{
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TEACHERS")]
    public partial class Teacher : APerson, IVisible
    {
        public Teacher()
        {
            Lessons = new HashSet<Lesson>();
            TeacherInfos = new HashSet<TeacherInfo>();
            AcademicDegrees = new HashSet<AcademicDegree>();
            ExamRoomRegisters = new HashSet<ExamRoomRegister>();
            LessonRoomRegisters = new HashSet<LessonRoomRegister>();
        }

        [Key]
        [Column("TEACHER_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

 
        [Column("TEACHER_NAME")]
        public override string Name { get; set; }


        [Column("TEACHER_SURNAME")]
        public override string Surname { get; set; }


        [Column("TEACHER_PATRONYMIC")]
        public override string Patronymic { get; set; }

        [Column("TEACHER_VISIBILITY")]
        public bool Visibility { get; set; }


        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<TeacherInfo> TeacherInfos { get; set; }
        public virtual ICollection<AcademicDegree> AcademicDegrees { get; set; }
        public virtual ICollection<ExamRoomRegister> ExamRoomRegisters { get; set; }
        public virtual ICollection<LessonRoomRegister> LessonRoomRegisters { get; set; }

        public override string ToString()
        {
            return $"{Surname} {Name}";
        }
    }
}
