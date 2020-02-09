namespace Dispatcher.Entity.Entities
{
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GROUPS")]
    public partial class Group : AEntity, IVisible
    {
        public Group()
        {
            Students = new HashSet<Student>();
            GroupLessonPair = new HashSet<GroupLessonPair>();
            LessonRoomRegisters = new HashSet<LessonRoomRegister>();
        }

        [Key]
        [Column("GROUP_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }


        [Column("GROUP_NAME")]
        public string Name { get; set; }

        [Column("GROUP_VISIBILITY")]
        public bool Visibility { get; set; }

        [Column("COURSE_ID")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<GroupLessonPair> GroupLessonPair { get; set; }
        public virtual ICollection<LessonRoomRegister> LessonRoomRegisters { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
