namespace Dispatcher.Entity.Entities
{
    using System;
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EXAM_ROOM_REGISTERS")]
    public partial class ExamRoomRegister: ARegister, IVisible
    {
        public ExamRoomRegister()
        {
            Supervisiors = new HashSet<Teacher>();
            GroupLessonPairs = new HashSet<GroupLessonPair>();
        }

        [Key]
        [Column("EXAM_ROOM_REGISTER_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }


        [Column("EXAM_ROOM_REGISTER_VISIBILITY")]
        public bool Visibility { get; set; }

        [Column("EXAM_DATE")]
        public DateTime? ExamDate { get; set; }

            
        public virtual Room Room { get; set; }
        public virtual Hour Hour { get; set; }
        public virtual ICollection<Teacher> Supervisiors { get; set; }
        public virtual ICollection<GroupLessonPair> GroupLessonPairs { get; set; }
    }
}
