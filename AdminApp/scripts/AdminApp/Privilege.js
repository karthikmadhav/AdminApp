
$(document).ready(function () {
    $("#privTable").hide();
    $("#tblValue").html("");
    ClearErrorMsg();
});
$("#RoleID").change(function () {
    if (parseInt($("#RoleID option:selected").val()) > 0) {
        var userPermission = {
            RoleID: $("#RoleID option:selected").val()
        };
        $.ajax({
            type: "POST",
            data: JSON.stringify(userPermission),
            url: "/MasterSettings/GetPrivilegeByRole",
            contentType: 'application/json',
            dataType: "json",
            beforeSend: function () {

            },
            success: function (data) {
                if (data == "error") {
                    return ShowErrorMsg(errorMsg.roleSubmitError);
                }
                $("#privTable").show();
                $("#tblPriv > tbody").empty();
                var trHTML = '';
                $.each(data, function (i, item) {
                    trHTML += '<tbody><tr><td>' + item.MenuName + '</td><td>' + item.CanView + '</td><td>' + item.CanCreate + '</td><td>' + item.CanEdit + '</td><td>' + item.CanDelete + '</td></tr></tbody>';
                });
                $('#tblPriv').append(trHTML);
                $("#tblValue").html("");
            },
            failure: function (data) {
                $("#tblValue").html("No Privilege's mapped with this Role");
                $("#privTable").hide();
                return ShowErrorMsg(errorMsg.roleSubmitError);
            },
            error: function (data) {
                $("#privTable").hide();
                $("#tblValue").html("No Privilege's mapped with this Role");
                return ShowErrorMsg(errorMsg.roleSubmitError);
            },
            complete: function () {

            }
        });
    }
});