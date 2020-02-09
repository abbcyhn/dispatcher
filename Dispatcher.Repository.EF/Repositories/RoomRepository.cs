namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using Context;
    using System.Linq;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Collections.Generic;

    public class RoomRepository : EFRepositoryMapper, IRoomRepository
    {
        public RoomRepository(EFDbContext ctx) : base(ctx) { }


        public Room SelectById(int id)
        {
            return ctx.Rooms.Find(id);
        }
        public int SelectCapacity(Room room)
        {
            return SelectById(room.Id).Capacity;
        }
        public IEnumerable<Room> SelectAll()
        {
            return ctx.Rooms
                .Where(r => r.Visibility)
                .OrderBy(r => r.BuildingId)
                .ThenBy(r => r.Name);
        }
        public IEnumerable<Room> SelectAllByCapacity(int capacity)
        {
            return ctx.Rooms
                .Where(g => g.Capacity >= capacity);
        }

        public void Insert(Room entity)
        {
            entity.Visibility = true;
            ctx.Rooms.Add(entity);
        }
        public void Update(Room entity)
        {
            var oldEntity = SelectById(entity.Id);

            oldEntity.Name = entity.Name;
            oldEntity.Capacity = entity.Capacity;
            oldEntity.Description = entity.Description;
            oldEntity.BuildingId = entity.BuildingId;
            oldEntity.RoomTypeId = entity.RoomTypeId;
        }
        public void Delete(Room entity)
        {
            entity.Visibility = false;
        }
    }
}
