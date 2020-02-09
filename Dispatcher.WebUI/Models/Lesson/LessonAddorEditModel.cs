namespace Dispatcher.WebUI.Models.Lesson
{
    using Shared;
    using Entity.Entities;
    using UnitOfWorkPattern;
    using System.Collections.Generic;

    public class LessonAddOrEditModel : AddOrEditViewModel
    {
        public LessonAddOrEditModel(IUnitOfWork uow, string post, int lessonId = 0) : base(uow, post, lessonId) { }

        public Lesson Lesson
        {
            get { return Uow.Lessons.SelectById(EntityId) ?? new Lesson(); }
        }
        public IEnumerable<GenericViewModel<Teacher>> TeacherModels
        {
            get
            {
                var allTeachers = Uow.Teachers.SelectAll();
                var selectedTeachers = Lesson?.Teachers;

                return GenericModelCreator.GetGenericModel(allTeachers, selectedTeachers);
            }
        }
    }
}