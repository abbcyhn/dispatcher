namespace Dispatcher.Entity.Entities
{
    using Abstract;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LAG_ROOM_TYPES")]
    public class RoomType : AEntity
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        [Key]
        [Column("ROOM_TYPE_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Column("ROOM_TYPE_NAME")]
        public string Name { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}