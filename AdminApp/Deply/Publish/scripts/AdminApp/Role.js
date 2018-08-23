function addNewRole() {
    $("#divTitle").html("New Role");
    $("#btnSave").text("Save");
    $('#txtRollName').val('');
    $("#hdnRoleID").val(null);
    showhide();
    ClearErrorMsg();
}
function cancel() {
    $("#newRole").hide();
    ClearErrorMsg();
}
function saveRole() {
    //Input Validation 
    var valResult;
    var inputValue = $('#txtRollName').val();
    inputValue = inputValue.replace(/-/g, '');
    if (inputValue != '') {
        var regex = /[`~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/]/gi;
        var isSplChar = regex.test(inputValue);
        if(isSplChar)
        {
            $('#lblRollName').html("** Should not contain special characters.").show();
            $('#txtRollName').addClass("is-invalid");
            return false;
        }
    }
    if (inputValue == '') {
        $('#lblRollName').html("** Role Name is required.").show();
        $('#txtRollName').addClass("is-invalid");
        return false;
    }

    //Get Role ID Value
    var hdnRID;
    if ($("#hdnRoleID").val() != null && $("#hdnRoleID").val() != undefined)
        hdnRID = parseInt($("#hdnRoleID").val());
    else
        hdnRID = parseInt(0);

    //Populating Model Values 
    var TModel = {
        Name: $('#txtRollName').val(),
        RoleId: hdnRID
    };

    //Ajax Call to Save and Update
    $.ajax({
        type: "POST",
        data: JSON.stringify(TModel),
        url: "/MasterSettings/SaveRole",
        contentType: 'application/json',
        dataType: "json",
        beforeSend: function () {

        },
        success: function (data) {
            if ( data == "error") {
                return ShowErrorMsg(errorMsg.roleSubmitError);
            }
            $("#newRole").hide();
            location.reload(true);
        },
        failure: function (data) {
            return ShowErrorMsg(errorMsg.roleSubmitError);
        },
        error: function (data) {
            return ShowErrorMsg(errorMsg.roleSubmitError);
        },
        complete: function () {

        }
    });
}

function editRoleDetails(roleID) {
    //Get Role Name based on row click
    $('#tblRole tr').each(function () {
        if (!this.rowIndex) return; // skip first row
        var rowRoleID = this.cells[0].innerHTML;
        if (parseInt(roleID) == parseInt(rowRoleID)) {
            var names = this.cells[1].innerHTML;
            $('#txtRollName').val(names.replace(/ /g, ''));
        }
    });
    $("#hdnRoleID").val(roleID);
    $("#divTitle").html("Update Role");
    $("#btnSave").text("Update");
    showhide();
    ClearErrorMsg();
}
function showhide() {
    $("#newRole").show();
    $('#txtRollName').removeClass("is-invalid");
    $('#lblRollName').html("").hide();

}
$('#txtRollName').keyup(function () {
    var inputValue = $('#txtRollName').val();
    if (parseInt(inputValue) > 0) {
        $('#lblRollName').html("** Should not contains numbers.").show();
        $('#txtRollName').addClass("is-invalid");
        return false;
    }
    inputValue = inputValue.replace(/-/g, '');
    if (inputValue != '') {
        var regex = /[`~!@#$%^&*()_|+\-=?;:'",.<>\{\}\[\]\\\/]/gi;
        var isSplChar = regex.test(inputValue);
        if (isSplChar) {
            $('#lblRollName').html("** Should not contain special characters.").show();
            $('#txtRollName').addClass("is-invalid");
            return false;
        }
        else
        {
            $('#txtRollName').removeClass("is-invalid");
            $('#lblRollName').html("").hide();
        }
    }
    
});