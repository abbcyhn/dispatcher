namespace Dispatcher.WebUI.Helpers
{
    using Models.Room;
    using Models.Group;
    using Models.Lesson;
    using Models.Teacher;
    using Models.Student;
    using Entity.Entities;
    using Models.ExamRoomRegister;
    using Models.LessonRoomRegister;

    public static class ModelToEntityConverter
    {
        public static Room ToEntity(this RoomModel model)
        {
            Room room = new Room
            {
                Id = model.Id,
                Name = model.Name,
                Capacity = model.Capacity,
                BuildingId = model.BuildingId,
                RoomTypeId = model.RoomTypeId
            };

            return room;
        }

        public static Group ToEntity(this GroupModel model)
        {
            Group group = new Group()
            {
                Id = model.Id,
                Name = model.Name,
                CourseId = model.CourseId,
            };

            return group;
        }

        public static Lesson ToEntity(this LessonModel model)
        {
            Lesson lesson = new Lesson
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };


            if (model.TeacherIds != null)
                foreach (int teacherId in model.TeacherIds)
                    lesson.Teachers.Add(new Teacher { Id = teacherId });


            return lesson;
        }

        public static Student ToEntity(this StudentModel model)
        {
            Student student = new Student
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Patronymic = model.Patronymic,
                GroupId = model.GroupId
            };

            return student;
        }

        public static Teacher ToEntity(this TeacherModel model)
        {
            Teacher teacher = new Teacher
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Patronymic = model.Patronymic,
            };

            if (model.AcademicDegreeIds != null)
                foreach (int degreeId in model.AcademicDegreeIds)
                    teacher.AcademicDegrees.Add(new AcademicDegree { Id = degreeId });

            teacher.TeacherInfos.Add(new TeacherInfo
            {
                LectureRoomId = model.LectureRoomId,
                CounselHourId = model.CounselHourId,
                CounselRoomId = model.CounselRoomId,
            });


            return teacher;
        }

        public static ExamRoomRegister ToEntity(this ERRegisterModel model)
        {
            var register = new ExamRoomRegister
            {
                Id = model.Id,
                RoomId = model.RoomId,
                ExamDate = model.ExamDate,
                HourId = model.HourId
            };

            if (model.SupervisiorIds != null)
                foreach (var id in model.SupervisiorIds)
                    register.Supervisiors.Add(new Teacher { Id = id });

            if (model.GroupIds != null)
                foreach (var id in model.GroupIds)
                    register.GroupLessonPairs.Add(new GroupLessonPair { GroupId = id });

            return register;
        }

        public static LessonRoomRegister ToEntity(this LRRegisterModel model)
        {
            var register = new LessonRoomRegister
            {
                Id = model.Id,
                LessonId = model.LessonId,
                TeacherId = model.TeacherId,
                RoomId = model.RoomId,
                WeekId = model.WeekId,
                DayId = model.DayId,
                HourId = model.HourId
            };

            if(model.GroupIds != null)
                foreach (var id in model.GroupIds)
                    register.Groups.Add(new Group { Id = id });

            return register;
        }
    }
}