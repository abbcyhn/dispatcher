function Save() {
    IsRoomAndTeacherAvailable(function (data) {
        console.log("data is", data);
        if (data.HasError) {
            ShowErrorMessage(data.Message);
        }
        else {
            console.log("lrForm is submitted");
            $("#lrForm").submit();
        }
    });
}