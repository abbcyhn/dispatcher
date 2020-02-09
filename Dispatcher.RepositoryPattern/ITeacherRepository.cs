namespace Dispatcher.RepositoryPattern
{
    using Entity.Entities;
    using System.Collections.Generic;

    public interface ITeacherRepository : IRepository<Teacher>
    {
        IEnumerable<Teacher> SelectAllByLessonId(int lessonId);
    }
}