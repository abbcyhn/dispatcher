$(document).ready(function () {
    var lessonValidator = $("#lessonForm").validate({
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
            "LessonModel.Name": "required",
            "LessonModel.Description": "required",
        }
    });
});