$(document).ready(function () {
    var lessonValidator = $("#teacherForm").validate({
        errorPlacement: function (error, element) {
            return true;
        },
        highlight: function (element) {
            $(element).parent().parent().addClass("error");
        },
        unhighlight: function (element) {
            $(element).parent().parent().removeClass("error");
        },
        rules: {
            "TeacherModel.Name": "required",
            "TeacherModel.Surname": "required",
            "TeacherModel.Patronymic": "required"
        }
    });
});