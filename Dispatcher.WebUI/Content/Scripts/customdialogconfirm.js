function ShowDialogConfirm(formId) {
    $("#dialog-confirm").dialog({
        resizable: false,
        height: "auto",
        width: 400,
        modal: true,
        buttons: {
            "Bəli": function () {
                Submit(formId, true);
                $(this).dialog("close");
            },
            "Xeyr": function () {
                Submit(formId, false);
                $(this).dialog("close");
            }
        }
    });
}


function ShowErrorMessage(message)
{
    $("#dialog-confirm-message").html(message);
    $("#dialog-confirm").dialog({
        resizable: false,
        height: "auto",
        width: 400,
        modal: true,
        buttons: {
            "Yaxşı": function () {
                $(this).dialog("close");
            }
        }
    });
}


function Submit(formId, isSubmit) {
    var form = $("#" + formId);
    if (isSubmit) {
        form.submit();
    }
    console.log(formId + " " + isSubmit);
}