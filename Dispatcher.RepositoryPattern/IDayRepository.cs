namespace Dispatcher.RepositoryPattern
{
    using Entity.Entities;
    using System.Collections.Generic;

    public interface IDayRepository : IRepository<Day>
    {
        IEnumerable<Day> SelectOnlyLessonDays();
    }
}