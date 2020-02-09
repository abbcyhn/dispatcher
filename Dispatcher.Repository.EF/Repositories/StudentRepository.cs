namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using Context;
    using System.Linq;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Collections.Generic;

    public class StudentRepository : EFRepositoryMapper, IStudentRepository
    {
        public StudentRepository(EFDbContext ctx) : base(ctx) { }

        public Student SelectById(int id)
        {
            return ctx.Students.Find(id);
        }
        public IEnumerable<Student> SelectAll()
        {
            return ctx.Students
                .Where(s => s.Visibility)
                .OrderBy(s => s.Group.Name)
                .ThenBy(s => s.Surname);
        }

        public void Insert(Student entity)
        {
            entity.Visibility = true;
            ctx.Students.Add(entity);
        }
        public void Update(Student entity)
        {
            var oldEntity = SelectById(entity.Id);
            oldEntity.Name = entity.Name;
            oldEntity.Surname = entity.Surname;
            oldEntity.Patronymic = entity.Patronymic;
            oldEntity.GroupId = entity.GroupId;
        }
        public void Delete(Student entity)
        {
            entity.Visibility = false;
        }
    }
}
