$(document).ready(function () {
    var lessonValidator = $("#groupForm").validate({
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
            "GroupModel.Name": {
                required: true,
                maxlength: 5
            },
        }
    });
});