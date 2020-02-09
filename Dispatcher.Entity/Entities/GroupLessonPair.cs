namespace Dispatcher.Entity.Entities
{
    using Abstract;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EXAM_ROOM_REGISTERS_GROUP_LESSON_PAIRS")]
    public class GroupLessonPair : AEntity
    {
        [Key]
        [Column("GROUP_LESSON_PAIR_ID")]
        public override int Id { get; set; }

        [Column("EXAM_ROOM_REGISTER_ID")]
        public int ExamRoomRegisterId { get; set; }
        public virtual ExamRoomRegister ExamRoomRegister { get; set; }

        [Column("GROUP_ID")]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        [Column("LESSON_ID")]
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public override string ToString()
        {
            return $"{Group.Name} {Lesson?.Name}";
        }
    }
}