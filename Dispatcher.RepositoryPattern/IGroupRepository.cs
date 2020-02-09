namespace Dispatcher.RepositoryPattern
{
    using Entity.Entities;
    using System.Collections.Generic;

    public interface IGroupRepository : IRepository<Group>
    {
        int SelectCapacity(int id);
        int SelectCapacity(int[] ids);
        int SelectCapacity(Group group);
        int SelectCapacity(IEnumerable<Group> groups);

        IEnumerable<Group> SelectAllExceptThese(int[] groupIds);
    }
}