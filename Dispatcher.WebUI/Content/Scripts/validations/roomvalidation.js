$(document).ready(function () {
    var lessonValidator = $("#roomForm").validate({
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
            "RoomModel.Name": {
                required: true,
                number: true
             },
            "RoomModel.Capacity": {
                required: true,
                number: true
             }
        }
    });
});