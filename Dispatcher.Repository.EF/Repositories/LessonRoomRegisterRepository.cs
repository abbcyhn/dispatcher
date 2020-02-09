namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using Context;
    using System.Linq;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Collections.Generic;

    public class LessonRoomRegisterRepository : EFRepositoryMapper, ILessonRoomRegisterRepository
    {
        public LessonRoomRegisterRepository(EFDbContext ctx) : base(ctx) { }

        public LessonRoomRegister SelectById(int id)
        {
            return ctx.LessonRoomRegisters.Find(id);
        }
        public LessonRoomRegister SelectByRoomAndDate(LessonRoomRegister entity)
        {
            return ctx.LessonRoomRegisters
                .Where(lr => lr.Visibility)
                .Where(lr => lr.RoomId == entity.RoomId)
                .Where(lr => lr.WeekId == entity.WeekId)
                .Where(lr => lr.DayId == entity.DayId)
                .Where(lr => lr.HourId == entity.HourId)
                .FirstOrDefault();
        }
        public LessonRoomRegister SelectByTeacherAndDate(LessonRoomRegister entity)
        {
            return ctx.LessonRoomRegisters
                .Where(lr => lr.Visibility)
                .Where(lr => lr.TeacherId == entity.TeacherId)
                .Where(lr => lr.WeekId == entity.WeekId)
                .Where(lr => lr.DayId == entity.DayId)
                .Where(lr => lr.HourId == entity.HourId)
                .FirstOrDefault();
        }
        public IEnumerable<LessonRoomRegister> SelectAll()
        {
            return ctx.LessonRoomRegisters.Where(lr => lr.Visibility);
        }

        public void Insert(LessonRoomRegister entity)
        {
            entity.Visibility = true;

            var groups = new List<Group>();
            foreach (var group in entity.Groups)
            {
                var g = ctx.Groups.Find(group.Id);
                groups.Add(g);

            }
            entity.Groups.Clear();


            foreach (var group in groups)
                entity.Groups.Add(group);
            ctx.LessonRoomRegisters.Add(entity);
        }
        public void Update(LessonRoomRegister entity)
        {
            var oldEntity = SelectById(entity.Id);

            oldEntity.LessonId = entity.LessonId;
            oldEntity.TeacherId = entity.TeacherId;
            oldEntity.RoomId = entity.RoomId;
            oldEntity.WeekId = entity.WeekId;
            oldEntity.DayId = entity.DayId;
            oldEntity.HourId = entity.HourId;

            #region update groups                                 
            oldEntity.Groups.Clear();
            foreach (var group in entity.Groups)
            {
                var newGroup = ctx.Groups.Find(group.Id);
                if (newGroup != null)
                    oldEntity.Groups.Add(newGroup);
            }
            #endregion
        }
        public void Delete(LessonRoomRegister entity)
        {
            entity.Visibility = false;
        }
    }
}