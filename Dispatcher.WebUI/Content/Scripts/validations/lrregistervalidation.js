$(document).ready(function () {
    var lessonValidator = $("#lrForm").validate({
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
            "LRModel.RoomId": {
                required: true
            },
            "LRModel.TeacherId": {
                required: true
            },
            "LRModel.GroupIds[]": {
                required: true
            },
        },
        submitHandler: function (form)
        {
            var groups = $("#groups").val();
            if (groups == null) {
                $("#groups_chzn_main").addClass("error");
                $("#groups_chzn").css("border", "1px solid #b94a48");
                return false;
            }
            else {
                $("#groups_chzn_main").removeClass("error");
                $("#groups_chzn").css("border", "");
                return true;
            }
        }
    });
});