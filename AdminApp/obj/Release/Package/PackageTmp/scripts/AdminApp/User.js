$(document).ready(function () {
    removeError();
});
function removeError() {
    $('#FirstName').removeClass("is-invalid");
    $('#Address').removeClass("is-invalid");
    $('#EmployeeCode').removeClass("is-invalid");
    $('#City').removeClass("is-invalid");
    $('#State').removeClass("is-invalid");
    $('#Country').removeClass("is-invalid");
    $('#Pincode').removeClass("is-invalid");
    $('#UserName').removeClass("is-invalid");
    $('#Password').removeClass("is-invalid");
    $('#CompanyID').removeClass("is-invalid");
    $('#RoleId').removeClass("is-invalid");
}
function btnSave() {
    removeError();
    var valRes = true;
    if ($('#FirstName').val() == '') {
        $('#FirstName').addClass("is-invalid");
        valRes = false;
    }
    if ($('#Address').val() == '') {
        $('#Address').addClass("is-invalid");
        valRes = false;
    }
    if ($('#EmployeeCode').val() == '') {
        $('#EmployeeCode').addClass("is-invalid");
        valRes = false;
    }
    if ($('#City').val() == '') {
        $('#City').addClass("is-invalid");
        valRes = false;
    }
    if ($('#State').val() == '') {
        $('#State').addClass("is-invalid");
        valRes = false;
    }
    if ($('#Country').val() == '') {
        $('#Country').addClass("is-invalid");
        valRes = false;
    }
    if ($('#Pincode').val() == '') {
        $('#Pincode').addClass("is-invalid");
        valRes = false;
    }
  
    if ($('#UserName').val() == '') {
        $('#UserName').addClass("is-invalid");
        valRes = false;
    }

    if ($('#Password').val() == '') {
        $('#Password').addClass("is-invalid");
        valRes = false;
    }
    if ($("#CompanyID").val() == "") {
        $('#CompanyID').addClass("is-invalid");
        valRes = false;
    }
    if ($("#RoleId").val() == "") {
        $('#RoleId').addClass("is-invalid");
        valRes = false;
    }
   
    return valRes;
}
function loadUserDetails(userID) {
    //Ajax Call to Save and Update
    $.ajax({
        type: "GET",
        data: { "UserID": userID },
        url: "/UserDetails/GetUserDetails",
        contentType: 'application/json',
        dataType: "json",
        beforeSend: function () {

        },
        success: function (data) {
            if (data == "error") {
                $("#divModal").hide();
            }
            else {
                $("#cmpName").html(data.CompanyName);
                $("#roleName").html(data.RoleName);
                $("#empCode").html(data.EmployeeCode);
                $("#fstName").html(data.FirstName);
                $("#lstName").html(data.LastName);
                $("#userName").html(data.UserName);
                $("#phone").html(data.PhoneNumber);
                $("#mail").html(data.PrimaryEmailID);
                $("#cmpAddr").html(data.Address);
                $("#cmpAddr1").html(data.Address1);
                $("#cmpCity").html(data.City);
                $("#cmpState").html(data.State);
                $("#cmpCountry").html(data.Country);
                $("#cmpPincode").html(data.Pincode);
            }
        },
        failure: function (data) {
            $("#divModal").hide();
        },
        error: function (data) {
            $("#divModal").hide();
        },
        complete: function () {

        }
    });
}