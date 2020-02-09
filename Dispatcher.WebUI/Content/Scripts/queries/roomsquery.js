GetAvailableRooms();

$("#groups").change(function () {
    GetAvailableRooms();
});

function GetAvailableRooms()
{
    var ids = $("#groups").val();
    var id = "ModelRoomId";
    var name = "LRModel.RoomId";

    if (ids == null)
        return;

    $.ajax({
        type: "GET",
        url: roomsUrl,
        data: {
            id: id,
            name: name,
            groupIds: ids,
        }
    }).done(function (partialViewResult) {
        $("#rooms").html(partialViewResult);
    });
}