namespace Dispatcher.RepositoryPattern
{
    using Entity.Entities;
    using System.Collections.Generic;

    public interface IRoomRepository : IRepository<Room>
    {
        int SelectCapacity(Room room);
        IEnumerable<Room> SelectAllByCapacity(int capacity);
    }
}