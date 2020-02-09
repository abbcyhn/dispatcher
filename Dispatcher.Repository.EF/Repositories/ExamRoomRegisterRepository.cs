namespace Dispatcher.Repository.EF.Repositories
{
    using Mapper;
    using Context;
    using System.Linq;
    using Entity.Entities;
    using RepositoryPattern;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;

    public class ExamRoomRegisterRepository : EFRepositoryMapper, IExamRoomRegisterRepository
    {
        public ExamRoomRegisterRepository(EFDbContext ctx) : base(ctx) { }

        public ExamRoomRegister SelectById(int id)
        {
            return ctx.ExamRoomRegisters.Find(id);
        }
        public ExamRoomRegister SelectByRoomAndDate(ExamRoomRegister entity)
        {
            return ctx.ExamRoomRegisters
                .Where(lr => lr.Visibility)
                .Where(lr => lr.RoomId == entity.RoomId)
                .Where(lr => EntityFunctions.CreateDateTime(lr.ExamDate.Value.Year, lr.ExamDate.Value.Month, lr.ExamDate.Value.Day, 0,0,0) == entity.ExamDate.Value)
                //.Where
                //( lr => 
                //        lr.ExamDate.Value.Year == entity.ExamDate.Value.Year
                //    &&
                //        lr.ExamDate.Value.Month == entity.ExamDate.Value.Month
                //    &&
                //        lr.ExamDate.Value.Day == entity.ExamDate.Value.Day
                //)
                .Where(lr => lr.HourId == entity.HourId)
                .FirstOrDefault();
        }
        public IEnumerable<ExamRoomRegister> SelectBySupervisiorsAndDate(ExamRoomRegister entity)
        {
            return ctx.ExamRoomRegisters
                .Where(lr => lr.Visibility)
                .Where(lr => lr.GroupLessonPairs.Any(gpl => entity.GroupLessonPairs.Contains(gpl)))
                .Where(lr => lr.ExamDate == entity.ExamDate)
                .Where(lr => lr.HourId == entity.HourId);
        }
        public IEnumerable<ExamRoomRegister> SelectAll()
        {
            return ctx.ExamRoomRegisters.Where(lr => lr.Visibility);
        }

        public void Insert(ExamRoomRegister entity)
        {
            entity.Visibility = true;

            #region insert supervisiors
            var supervisiors = new List<Teacher>();
            foreach (var supervisior in entity.Supervisiors)
            {
                var s = ctx.Teachers.Find(supervisior.Id);
                supervisiors.Add(s);

            }
            entity.Supervisiors.Clear();

            foreach (var supervisior in supervisiors)
                entity.Supervisiors.Add(supervisior);
            #endregion

            ctx.ExamRoomRegisters.Add(entity);
        }
        public void Update(ExamRoomRegister entity)
        {
            var originalEntity = SelectById(entity.Id);

            originalEntity.RoomId = entity.RoomId;
            originalEntity.ExamDate = entity.ExamDate;
            originalEntity.HourId = entity.HourId;


            #region update supervisiors                                 
            originalEntity.Supervisiors.Clear();
            foreach (var supervisior in entity.Supervisiors)
            {
                var newSupervisior = ctx.Teachers.Find(supervisior.Id);
                if (newSupervisior != null)
                    originalEntity.Supervisiors.Add(newSupervisior);
            }
            #endregion

            #region update lesson and group pair
            foreach (var gpl in entity.GroupLessonPairs)
            {
                var originalChildItem = originalEntity.GroupLessonPairs
                    .Where(c => c.Id == gpl.Id && c.Id != 0)
                    .SingleOrDefault();
                // Is original child item with same ID in DB?
                if (originalChildItem != null)
                {
                    // Yes -> Update scalar properties of child item
                    var childEntry = ctx.Entry(originalChildItem);
                    childEntry.CurrentValues.SetValues(gpl);
                }
                else
                {
                    // No -> It's a new child item -> Insert
                    gpl.Id = 0;
                    originalEntity.GroupLessonPairs.Add(gpl);
                }
            }

            // Don't consider the child items we have just added above.
            // (We need to make a copy of the list by using .ToList() because
            // _dbContext.ChildItems.Remove in this loop does not only delete
            // from the context but also from the child collection. Without making
            // the copy we would modify the collection we are just interating
            // through - which is forbidden and would lead to an exception.)
            foreach (var item in
                         originalEntity.GroupLessonPairs.Where(c => c.Id != 0).ToList())
            {
                // Are there child items in the DB which are NOT in the
                // new child item collection anymore?
                if (!entity.GroupLessonPairs.Any(c => c.Id == item.Id))
                    // Yes -> It's a deleted child item -> Delete
                    ctx.GroupLessonPairs.Remove(item);
            }
            #endregion
        }
        public void Delete(ExamRoomRegister entity)
        {
            entity.Visibility = false;
        }
    }
}