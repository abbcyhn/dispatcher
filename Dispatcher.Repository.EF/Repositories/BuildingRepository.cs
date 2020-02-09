namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using Context;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Collections.Generic;

    public class BuildingRepository : EFRepositoryMapper, IBuildingRepository
    {
        public BuildingRepository(EFDbContext ctx) : base(ctx) { }


        public Building SelectById(int id)
        {
            return ctx.Buildings.Find(id);
        }
        public IEnumerable<Building> SelectAll()
        {
            return ctx.Buildings;
        }


        public void Insert(Building entity) { }
        public void Update(Building entity) { }
        public void Delete(Building entity) { }
    }


}
