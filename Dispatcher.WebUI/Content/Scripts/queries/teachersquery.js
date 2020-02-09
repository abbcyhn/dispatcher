GetAvailableTeachers();

$("#lessons").change(function () {
    GetAvailableTeachers();
});

function GetAvailableTeachers()
{
    var lessonId = $("#lessons").val();
    var id = "ModelTeacherId";
    var name = "LRModel.TeacherId";

    $.ajax({
        type: "GET",
        url: teachersUrl,
        data: {
            id: id,
            name: name,
            lessonId: lessonId,
        }
    }).done(function (partialViewResult) {
        $("#teachers").html(partialViewResult);
    });
}