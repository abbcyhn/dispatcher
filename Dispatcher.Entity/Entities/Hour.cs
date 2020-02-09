namespace Dispatcher.Entity.Entities
{
    using System;
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dispatcher.Entity.Helper;

    [Table("LAG_HOURS")]
    public partial class Hour : AEntity
    {
        public Hour()
        {
            TeacherInfos = new HashSet<TeacherInfo>();
            ExamRoomRegisters = new HashSet<ExamRoomRegister>();
            LessonRoomRegisters = new HashSet<LessonRoomRegister>();
        }

        [Key]
        [Column("HOUR_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [NotMapped]
        public string Name
        {
            get
            {
                return
                    $"{StartTime.ToString(@"hh\:mm")} - {EndTime.ToString(@"hh\:mm")}";
            }
        }

        [Column("START_TIME")]
        public TimeSpan StartTime { get; set; }
        [Column("END_TIME")]
        public TimeSpan EndTime { get; set; }

        [Column("HOUR_TYPE")]
        public HourType Type { get; set; }

        public virtual ICollection<TeacherInfo> TeacherInfos { get; set; }
        public virtual ICollection<ExamRoomRegister> ExamRoomRegisters { get; set; }
        public virtual ICollection<LessonRoomRegister> LessonRoomRegisters { get; set; }
    }
}
