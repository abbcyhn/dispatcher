namespace Dispatcher.WebUI.Models.Group
{
    using Entity.Abstract;

    public class GroupModel : AEntity
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
    }
}