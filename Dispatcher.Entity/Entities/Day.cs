namespace Dispatcher.Entity.Entities
{
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LAG_DAYS")]
    public class Day : AEntity
    {
        public Day()
        {
            LessonRoomRegisters = new HashSet<LessonRoomRegister>();
        }

        [Key]
        [Column("DAY_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Column("DAY_NAME")]
        public string Name { get; set; }

        [Column("DAY_PRIORITY")]
        public int Priority { get; set; }

        [Column("IS_LESSON_DAY")]
        public bool IsLessonDay { get; set; }

        public virtual ICollection<LessonRoomRegister> LessonRoomRegisters { get; set; }
    }
}