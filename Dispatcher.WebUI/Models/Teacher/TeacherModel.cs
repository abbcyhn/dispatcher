namespace Dispatcher.WebUI.Models.Teacher
{
    using Entity.Abstract;

    public class TeacherModel : APerson
    {
        public int LectureRoomId { get; set; }
        public int CounselRoomId { get; set; }
        public int CounselHourId { get; set; }

        public int[] AcademicDegreeIds { get; set; }
    }
}