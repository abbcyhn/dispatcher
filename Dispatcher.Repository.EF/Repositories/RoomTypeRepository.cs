namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using System;
    using Context;
    using System.Linq;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Collections.Generic;

    public class RoomTypeRepository : EFRepositoryMapper, IRoomTypeRepository
    {
        public RoomTypeRepository(EFDbContext ctx) : base(ctx) { }

        public RoomType SelectById(int id)
        {
            return ctx.RoomTypes.Find(id);
        }

        public IEnumerable<RoomType> SelectAll()
        {
            return ctx.RoomTypes;
        }

        public void Insert(RoomType entity) { }
        public void Update(RoomType entity) { }
        public void Delete(RoomType entity) { }
    }
}