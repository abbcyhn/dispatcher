namespace Dispatcher.Entity.Entities
{
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LAG_LESSONS")]
    public partial class Lesson : AEntity, IVisible
    {
        public Lesson()
        {
            Teachers = new HashSet<Teacher>();
            GroupLessonPairs = new HashSet<GroupLessonPair>();
            LessonRoomRegisters = new HashSet<LessonRoomRegister>();
        }

        [Key]
        [Column("LESSON_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }


        [Column("LESSON_NAME")]
        public string Name { get; set; }


        [Column("LESSON_DESCRIPTION")]
        public string Description { get; set; }

        [Column("LESSON_VISIBILITY")]
        public bool Visibility { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<GroupLessonPair> GroupLessonPairs { get; set; }
        public virtual ICollection<LessonRoomRegister> LessonRoomRegisters { get; set; }
    }
}
