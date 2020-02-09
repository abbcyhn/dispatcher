namespace Dispatcher.Entity.Entities
{
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("LAG_ROOMS")]
    public partial class Room : AEntity, IVisible
    {
        public Room()
        {
            //TEACHERS_INFOS = new HashSet<TeacherInfo>();
            //TEACHERS_INFOS1 = new HashSet<TeacherInfo>();
            ExamRoomRegisters = new HashSet<ExamRoomRegister>();
            LessonRoomRegisters = new HashSet<LessonRoomRegister>();
        }

        [Key]
        [Column("ROOM_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Column("ROOM_NAME")]
        public int Name { get; set; }

        [Column("ROOM_CAPACITY")]
        public int Capacity { get; set; }

        [Column("ROOM_DESCRIPTION")]
        public string Description { get; set; }

        [Column("ROOM_VISIBILITY")]
        public bool Visibility { get; set; }

        [Column("BUILDING_ID")]
        public int BuildingId { get; set; }
        public virtual Building Building { get; set; }

        [Column("ROOM_TYPE_ID")]
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }


        //public virtual ICollection<TeacherInfo> TEACHERS_INFOS { get; set; }
        //public virtual ICollection<TeacherInfo> TEACHERS_INFOS1 { get; set; }
        public virtual ICollection<ExamRoomRegister> ExamRoomRegisters { get; set; }
        public virtual ICollection<LessonRoomRegister> LessonRoomRegisters { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}