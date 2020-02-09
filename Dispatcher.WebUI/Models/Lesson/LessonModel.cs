namespace Dispatcher.WebUI.Models.Lesson
{
    using Entity.Abstract;

    public class LessonModel : AEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] TeacherIds { get; set; }
    }
}