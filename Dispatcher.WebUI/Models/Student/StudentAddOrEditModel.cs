namespace Dispatcher.WebUI.Models.Student
{
    using Shared;
    using Entity.Entities;
    using UnitOfWorkPattern;
    using System.Collections.Generic;

    public class StudentAddOrEditModel : AddOrEditViewModel
    {
        public StudentAddOrEditModel(IUnitOfWork uow, string postUrl, int entityId = 0) : base(uow, postUrl, entityId) { }

        public Student Student
        {
            get { return Uow.Students.SelectById(EntityId) ?? new Student(); }
        }
        public IEnumerable<GenericViewModel<Group>> GroupModels
        {
            get
            {
                var groups = Uow.Groups.SelectAll();
                var selectedGroup = new List<Group> { Student.Group };

                return GenericModelCreator.GetGenericModel(groups, selectedGroup);
            }
        }
    }
}