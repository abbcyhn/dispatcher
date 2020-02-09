namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using Context;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Collections.Generic;

    public class AcademicDegreeRepository : EFRepositoryMapper, IAcademicDegreeRepository
    {
        public AcademicDegreeRepository(EFDbContext ctx) : base(ctx) { }


        public AcademicDegree SelectById(int id)
        {
            return ctx.AcademicDegrees.Find(id);
        }
        public IEnumerable<AcademicDegree> SelectAll()
        {
            return ctx.AcademicDegrees;
        }


        public void Insert(AcademicDegree entity) { }
        public void Update(AcademicDegree entity) { }
        public void Delete(AcademicDegree entity) { }
    }

}
