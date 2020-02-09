namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using Context;
    using System.Linq;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Data.Entity;
    using System.Collections.Generic;

    public class TeacherRepository : EFRepositoryMapper, ITeacherRepository
    {
        public TeacherRepository(EFDbContext ctx) : base(ctx) { }


        public Teacher SelectById(int id)
        {
            return ctx.Teachers.Find(id);
        }
        public IEnumerable<Teacher> SelectAll()
        {
            return ctx.Teachers
                .Where(t => t.Visibility)
                .OrderBy(t => t.Surname);
        }
        public IEnumerable<Teacher> SelectAllByLessonId(int lessonId)
        {
            return ctx.Lessons
                .Where(l => l.Id == lessonId)
                .SelectMany(l => l.Teachers);
        }


        public void Insert(Teacher entity)
        {
            entity.Visibility = true;
            ctx.Teachers.Add(entity);
        }
        public void Update(Teacher entity)
        {
            Teacher oldEntity = SelectById(entity.Id);
            TeacherInfo oldTeacherInfo = oldEntity.TeacherInfos.ElementAt(0);
            TeacherInfo newTeacherInfo = entity.TeacherInfos.ElementAt(0);

            oldEntity.Name = entity.Name;
            oldEntity.Surname = entity.Surname;
            oldEntity.Patronymic = entity.Patronymic;
            oldTeacherInfo.LectureRoomId = newTeacherInfo.LectureRoomId;
            oldTeacherInfo.CounselRoomId = newTeacherInfo.CounselRoomId;
            oldTeacherInfo.CounselHourId = newTeacherInfo.CounselHourId;

            oldEntity.TeacherInfos.Clear();
            oldEntity.TeacherInfos.Add(oldTeacherInfo);


            #region update academic degrees                                 
            oldEntity.AcademicDegrees.Clear();
            foreach (var degree in entity.AcademicDegrees)
            {
                var newDegree = ctx.AcademicDegrees.Find(degree.Id);
                if (newDegree != null)
                    oldEntity.AcademicDegrees.Add(newDegree);
            }
            #endregion
        }
        public void Delete(Teacher entity)
        {
            entity.Visibility = false;
        }
    }
}