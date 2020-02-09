namespace Dispatcher.Entity.Abstract
{
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class ARegister : AEntity
    {
        [Column("ROOM_ID")]
        public int RoomId { get; set; }

        [Column("HOUR_ID")]
        public int HourId { get; set; }
    }
}
