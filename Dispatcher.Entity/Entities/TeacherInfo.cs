namespace Dispatcher.Entity.Entities
{
    using System;
    using Abstract;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TEACHERS_INFOS")]
    public partial class TeacherInfo : AEntity
    {
        [Key]
        [Column("TEACHER_INFO_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }


        [Column("TEACHER_ID", Order = 0)]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }


        [Column("LECTURE_ROOM_ID", Order = 1)]
        public int LectureRoomId { get; set; }
        public virtual Room LectureRoom { get; set; }


        [Column("COUNSEL_ROOM_ID", Order = 2)]
        public int CounselRoomId { get; set; }
        public virtual Room CounselRoom { get; set; }


        [Column("COUNSEL_HOUR_ID", Order = 3)]
        public int CounselHourId { get; set; }
        public virtual Hour CounselHour { get; set; }
    }
}
