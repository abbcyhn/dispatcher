namespace Dispatcher.RepositoryPattern
{
    using Entity.Abstract;
    using System.Collections.Generic;

    public interface IRepository<TEntity> where TEntity : AEntity
    {
        TEntity SelectById(int id);
        IEnumerable<TEntity> SelectAll();

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}