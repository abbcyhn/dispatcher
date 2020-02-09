namespace Dispatcher.Repository.EF.Repositories
{
    using System;
    using Mapper;
    using Context;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Collections.Generic;

    public class WeekRepository : EFRepositoryMapper, IWeekRepository
    {
        public WeekRepository(EFDbContext ctx) : base(ctx) { }

        public Week SelectById(int id)
        {
            return ctx.Weeks.Find(id);
        }
        public IEnumerable<Week> SelectAll()
        {
            return ctx.Weeks;
        }

        public void Insert(Week entity) { }
        public void Update(Week entity) { }
        public void Delete(Week entity) { }
    }
}
