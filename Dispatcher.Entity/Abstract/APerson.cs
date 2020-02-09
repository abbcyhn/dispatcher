namespace Dispatcher.Entity.Abstract
{
    public abstract class APerson : AEntity
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Patronymic { get; set; }
    }
}