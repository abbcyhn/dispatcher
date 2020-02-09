$.validator.addMethod(
    "azerbaijanDate",
    function (value, element) {
        var regex = /(^(((0[1-9]|1[0-9]|2[0-8])[-](0[1-9]|1[012]))|((29|30|31)[-](0[13578]|1[02]))|((29|30)[-](0[4,6,9]|11)))[-](19|[2-9][0-9])\d\d$)|(^29[-]02[-](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)/;
        return value.match(regex);
    },
    "Please enter a date in the format dd.mm.yyyy."
);

$(document).ready(function () {
    var lessonValidator = $("#erForm").validate({
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
            "LRModel.ExamDate": {
                required: true,
                azerbaijanDate: true
            },
            "LRModel.SupervisiorIds[]": {
                required: true
            },
            "LRModel.GroupIds[]": {
                required: true
            },
        },
        submitHandler: function (form)
        {
            var result = false;
            var groups = $("#groups").val();
            var teachers = $("#teachers").val();

            console.log("groups val %o", groups);
            console.log("teachers val %o", teachers);

            if (teachers == null) {
                result = false;
                $("#teachers_chzn_main").addClass("error");
                $("#teachers_chzn").css("border", "1px solid #b94a48");
            }
            else {
                result = true;
                $("#teachers_chzn_main").removeClass("error");
                $("#teachers_chzn").css("border", "");
            }


            if (groups == null) {
                result = false;
                $("#groups_chzn_main").addClass("error");
                $("#groups_chzn").css("border", "1px solid #b94a48");
            }
            else {
                result = true;
                $("#groups_chzn_main").removeClass("error");
                $("#groups_chzn").css("border", "");
            }

            return result;
        }
    });
});