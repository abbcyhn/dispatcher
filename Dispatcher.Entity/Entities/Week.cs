namespace Dispatcher.Entity.Entities
{
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LAG_WEEKS")]
    public class Week : AEntity
    {
        public Week()
        {
            LessonRoomRegisters = new HashSet<LessonRoomRegister>();
        }

        [Key]
        [Column("WEEK_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Column("WEEK_NAME")]
        public string Name { get; set; }

        public virtual ICollection<LessonRoomRegister> LessonRoomRegisters { get; set; }
    }
}