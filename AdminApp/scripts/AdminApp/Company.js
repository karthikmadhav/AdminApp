$(document).ready(function () {
    removeError();
});
function removeError() {
    $('#CompanyName').removeClass("is-invalid");
    $('#PrimaryPhoneNo').removeClass("is-invalid");
    $('#Address').removeClass("is-invalid");
    $('#City').removeClass("is-invalid");
    $('#Country').removeClass("is-invalid");
    $('#PrimaryMailID').removeClass("is-invalid");
    $('#GSTNO').removeClass("is-invalid");
    $('#State').removeClass("is-invalid");
    $('#Pincode').removeClass("is-invalid");
}
function btnSave() {
    removeError();
    var valRes = true;
    if ($('#CompanyName').val() == '') {
        $('#CompanyName').addClass("is-invalid");
        valRes = false;
    }
    if ($('#PrimaryPhoneNo').val() == '') {
        $('#PrimaryPhoneNo').addClass("is-invalid");
        valRes = false;
    }
    if ($('#Address').val() == '') {
        $('#Address').addClass("is-invalid");
        valRes = false;
    }
    if ($('#City').val() == '') {
        $('#City').addClass("is-invalid");
        valRes = false;
    }
    if ($('#Country').val() == '') {
        $('#Country').addClass("is-invalid");
        valRes = false;
    }
    if ($('#GSTNO').val() == '') {
        $('#GSTNO').addClass("is-invalid");
        valRes = false;
    }
    if ($('#PrimaryMailID').val() == '') {
        $('#PrimaryMailID').addClass("is-invalid");
        valRes = false;
    }
    if ($('#State').val() == '') {
        $('#State').addClass("is-invalid");
        valRes = false;
    }
    if ($('#Pincode').val() == '') {
        $('#Pincode').addClass("is-invalid");
        valRes = false;
    }
    return valRes;
}
function loadCompanyDetails(compID)
{
    //Ajax Call to Save and Update
    $.ajax({
        type: "GET",
        data: { "CompanyID": compID},
        url: "/CompanySettings/GetCompanyDetails",
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
                $("#cmpMail").html(data.PrimaryMailID);
                $("#cmpPhone").html(data.PrimaryPhoneNo);
                $("#cmpFax").html(data.Fax);
                $("#cmpWebsite").html(data.Website);
                $("#cmpGST").html(data.GSTNO);
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