namespace Dispatcher.WebUI.Models.Group
{
    using Shared;
    using Entity.Entities;
    using UnitOfWorkPattern;
    using System.Collections.Generic;

    public class GroupAddOrEditModel : AddOrEditViewModel
    {
        public GroupAddOrEditModel(IUnitOfWork uow, string postUrl, int groupId = 0) : base(uow, postUrl, groupId) { }

        public Group Group
        {
            get { return Uow.Groups.SelectById(EntityId) ?? new Group(); }
        }
        public IEnumerable<GenericViewModel<Course>> CourseModels
        {
            get
            {
                var allCourses = Uow.Courses.SelectAll();
                var selectedCourse = new List<Course> { Group.Course };

                return GenericModelCreator.GetGenericModel(allCourses, selectedCourse);
            }
        }
    }
}