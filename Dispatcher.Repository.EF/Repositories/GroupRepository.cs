namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using Context;
    using System.Linq;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Collections.Generic;

    public class GroupRepository : EFRepositoryMapper, IGroupRepository
    {
        public GroupRepository(EFDbContext ctx) : base(ctx) { }

        public Group SelectById(int id)
        {
            return ctx.Groups.Find(id);
        }
        public int SelectCapacity(int id)
        {
            return ctx.Groups.Find(id).Students.Count;
        }
        public int SelectCapacity(int[] ids)
        {
            int capacity = 0;

            foreach (var id in ids)
                capacity += SelectCapacity(id);

            return capacity;
        }
        public int SelectCapacity(Group group)
        {
            return SelectCapacity(group.Id);
        }
        public int SelectCapacity(IEnumerable<Group> groups)
        {
            int capacity = 0;

            foreach (var group in groups)
                capacity += SelectCapacity(group);

            return capacity;
        }

        public IEnumerable<Group> SelectAll()
        {
            return ctx.Groups
                .Where(g => g.Visibility)
                .OrderBy(g => g.Name);
        }
        public IEnumerable<Group> SelectAllExceptThese(int[] groupIds)
        {
            return ctx.Groups.Where(g => !groupIds.Contains(g.Id));
        }

        public void Insert(Group entity)
        {
            entity.Visibility = true;
            ctx.Groups.Add(entity);
        }
        public void Update(Group entity)
        {
            Group oldEntity = SelectById(entity.Id);
            oldEntity.Name = entity.Name;
            oldEntity.CourseId = entity.CourseId;
        }
        public void Delete(Group entity)
        {
            entity.Visibility = false;
        }
    }
}
