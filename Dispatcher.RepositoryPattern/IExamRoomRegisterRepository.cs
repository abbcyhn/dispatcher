namespace Dispatcher.RepositoryPattern
{
    using Entity.Entities;
    using System.Collections.Generic;

    public interface IExamRoomRegisterRepository : IRepository<ExamRoomRegister>
    {
        ExamRoomRegister SelectByRoomAndDate(ExamRoomRegister entity);
        IEnumerable<ExamRoomRegister> SelectBySupervisiorsAndDate(ExamRoomRegister entity);
    }
}