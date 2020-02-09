namespace Dispatcher.Entity.Entities
{
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LESSON_ROOM_REGISTERS")]
    public partial class LessonRoomRegister : ARegister, IVisible
    {
        public LessonRoomRegister()
        {
            Groups = new HashSet<Group>();
        }

        [Key]
        [Column("LESSON_ROOM_REGISTER_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Column("LESSON_ROOM_REGISTER_VISIBILITY")]
        public bool Visibility { get; set; }

        [Column("LESSON_ID")]
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        [Column("TEACHER_ID")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [Column("WEEK_ID")]
        public int WeekId { get; set; }
        public virtual Week Week { get; set; }

        [Column("DAY_ID")]
        public int DayId { get; set; }
        public virtual Day Day { get; set; }

        public virtual Room Room { get; set; }
        public virtual Hour Hour { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
