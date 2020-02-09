function IsRoomAndTeacherAvailable(successCallback) {
    var id = $("#ModelId").val();
    var roomId = $("#ModelRoomId").val();
    var examDate = $("#ModelExamDateId").val();
    var hourId = $("#ModelHourId").val();
    var teacherId = $("#ModelTeacherId").val();

    if (id == null) return;

    $.ajax({
        type: "GET",
        url: isRoomAndTeacherAvailableUrl,
        data: {
            id: id,
            roomId: roomId,
            examDate: examDate,
            hourId: hourId,
            teacherId: teacherId,
        }
    }).done(successCallback);
}