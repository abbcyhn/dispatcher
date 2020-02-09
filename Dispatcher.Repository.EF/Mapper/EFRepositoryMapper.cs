namespace Dispatcher.Repository.EF.Mapper
{
    using Context;

    public abstract class EFRepositoryMapper
    {
        protected EFDbContext ctx;

        public EFRepositoryMapper(EFDbContext ctx)
        {
            this.ctx = ctx;
        }
    }
}