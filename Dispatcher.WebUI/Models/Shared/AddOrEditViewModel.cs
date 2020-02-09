namespace Dispatcher.WebUI.Models.Shared
{
    using UnitOfWorkPattern;

    public abstract class AddOrEditViewModel
    {
        public AddOrEditViewModel(IUnitOfWork uow, string postUrl, int entityId = 0)
        {
            Uow = uow;
            PostUrl = postUrl;
            EntityId = entityId;
        }


        public string PostUrl { get; private set; }
        protected int EntityId { get; private set; }
        protected IUnitOfWork Uow { get; private set; }
    }
}