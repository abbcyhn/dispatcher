function IsRoomAndTeacherAvailable(successCallback) {
    var id = $("#ModelId").val();
    var roomId = $("#ModelRoomId").val();
    var weekId = $("#ModelWeekId").val();
    var dayId = $("#ModelDayId").val();
    var hourId = $("#ModelHourId").val();
    var teacherId = $("#ModelTeacherId").val();

    if (id == null) return;

    $.ajax({
        type: "GET",
        url: isRoomAndTeacherAvailableUrl,
        data: {
            id: id,
            roomId: roomId,
            weekId: weekId,
            dayId: dayId,
            hourId: hourId,
            teacherId: teacherId,
        }
    }).done(successCallback);
}