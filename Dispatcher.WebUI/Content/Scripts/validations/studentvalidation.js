$(document).ready(function () {
    var lessonValidator = $("#studentForm").validate({
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
            "StudentModel.Name": "required",
            "StudentModel.Surname": "required",
            "StudentModel.Patronymic": "required",
        }
    });
});