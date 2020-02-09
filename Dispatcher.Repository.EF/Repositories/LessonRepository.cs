namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using Context;
    using System.Linq;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Collections.Generic;

    public class LessonRepository : EFRepositoryMapper, ILessonRepository
    {
        public LessonRepository(EFDbContext ctx) : base(ctx) { }


        public Lesson SelectById(int id)
        {
            return ctx.Lessons.Find(id);
        }


        public IEnumerable<Lesson> SelectAll()
        {
            return ctx.Lessons
                .Where(l => l.Visibility)
                .OrderByDescending(l => l.Id);
        }


        public void Insert(Lesson entity)
        {
            entity.Visibility = true;

            var teachers = new List<Teacher>();
            foreach (var teacher in entity.Teachers)
            {
                var t = ctx.Teachers.Find(teacher.Id);
                teachers.Add(t);

            }
            entity.Teachers.Clear();


            foreach (var teacher in teachers)
                entity.Teachers.Add(teacher);
            ctx.Lessons.Add(entity);
        }


        public void Update(Lesson entity)
        {
            Lesson oldEntity = SelectById(entity.Id);

            oldEntity.Name = entity.Name;                           //update name
            oldEntity.Description = entity.Description;             //update surname

                                                                    // update teachers
            #region update teachers                                 
            oldEntity.Teachers.Clear();
            foreach (var teacher in entity.Teachers)
            {
                var newTeacher = ctx.Teachers.Find(teacher.Id);
                if (newTeacher != null)
                    oldEntity.Teachers.Add(newTeacher);
            }
            #endregion
        }


        public void Delete(Lesson entity)
        {
            entity.Visibility = false;
        }
    }
}
