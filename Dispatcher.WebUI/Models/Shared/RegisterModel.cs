namespace Dispatcher.WebUI.Models.Shared
{
    using Entity.Abstract;

    public class RegisterModel : AEntity
    {
        public int RoomId { get; set; }
        public int HourId { get; set; }
    }
}