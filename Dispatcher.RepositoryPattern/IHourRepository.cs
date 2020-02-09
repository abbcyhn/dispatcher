namespace Dispatcher.RepositoryPattern
{
    using Entity.Entities;
    using System.Collections.Generic;

    public interface IHourRepository : IRepository<Hour>
    {
        IEnumerable<Hour> SelectAllExamHour();
        IEnumerable<Hour> SelectAllLessonHour();
        IEnumerable<Hour> SelectAllCounselHour();
    }
}