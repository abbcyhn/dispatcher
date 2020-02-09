namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using Context;
    using RepositoryPattern;
    using Dispatcher.Entity.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DayRepository : EFRepositoryMapper, IDayRepository
    {
        public DayRepository(EFDbContext ctx) : base(ctx) { }

        public Day SelectById(int id)
        {
            return ctx.Days.Find(id);
        }
        public IEnumerable<Day> SelectAll()
        {
            return ctx.Days;
        }
        public IEnumerable<Day> SelectOnlyLessonDays()
        {
            return ctx.Days.Where(d => d.IsLessonDay);
        }


        public void Insert(Day entity) { }
        public void Delete(Day entity) { }
        public void Update(Day entity) { }
    }
}
