namespace Dispatcher.WebUI.Models.LessonRoomRegister
{
    using Shared;
    
    public class LRRegisterModel : RegisterModel
    {
        public int[] GroupIds { get; set; }
        public int LessonId { get; set; }
        public int TeacherId { get; set; }
        public int WeekId { get; set; }
        public int DayId { get; set; }
    }
}