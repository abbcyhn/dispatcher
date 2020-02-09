namespace Dispatcher.WebUI.Models.Room
{
    using Entity.Abstract;

    public class RoomModel : AEntity
    {
        public int Name { get; set; }
        public int Capacity { get; set; }

        public int BuildingId { get; set; }
        public int RoomTypeId { get; set; }
    }
}