namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using Context;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Collections.Generic;

    public class CourseRepository : EFRepositoryMapper, ICourseRepository
    {
        public CourseRepository(EFDbContext ctx) : base(ctx) { }


        public Course SelectById(int id)
        {
            return ctx.Courses.Find(id);
        }
        public IEnumerable<Course> SelectAll()
        {
            return ctx.Courses;
        }


        public void Insert(Course entity) { }
        public void Update(Course entity) { }
        public void Delete(Course entity) { }
    }
}