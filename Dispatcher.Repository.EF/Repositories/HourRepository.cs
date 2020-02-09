namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using Context;
    using System.Linq;
    using Entity.Helper;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Collections.Generic;


    public class HourRepository : EFRepositoryMapper, IHourRepository
    {
        public HourRepository(EFDbContext ctx) : base(ctx) { }

        public Hour SelectById(int id)
        {
            return ctx.Hours.Find(id);
        }
        public IEnumerable<Hour> SelectAll()
        {
            return ctx.Hours;
        }
        public IEnumerable<Hour> SelectAllExamHour()
        {
            return ctx.Hours.Where(h => h.Type == HourType.Exam);
        }
        public IEnumerable<Hour> SelectAllLessonHour()
        {
            return ctx.Hours.Where(h => h.Type == HourType.Lesson);
        }
        public IEnumerable<Hour> SelectAllCounselHour()
        {
            return ctx.Hours.Where(h => h.Type == HourType.Counsel);
        }

        public void Insert(Hour entity) { }
        public void Update(Hour entity) { }
        public void Delete(Hour entity) { }
    }
}
