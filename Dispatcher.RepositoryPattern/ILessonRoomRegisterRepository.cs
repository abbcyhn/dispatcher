namespace Dispatcher.RepositoryPattern
{
    using Entity.Entities;

    public interface ILessonRoomRegisterRepository : IRepository<LessonRoomRegister>
    {
        LessonRoomRegister SelectByRoomAndDate(LessonRoomRegister entity);
        LessonRoomRegister SelectByTeacherAndDate(LessonRoomRegister entity);
    }
}