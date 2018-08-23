$(document).ready(function () {
    removeError();
});
function removeError() {
    $('#CompanyName').removeClass("is-invalid");
    $('#PrimaryPhoneNo').removeClass("is-invalid");
    $('#PrimaryMailID').removeClass("is-invalid");
    $('#BillingAddress').removeClass("is-invalid");
    $('#BillingCity').removeClass("is-invalid");
    $('#BillingCountry').removeClass("is-invalid");
    $('#BillingState').removeClass("is-invalid");
    $('#BillingPincode').removeClass("is-invalid");
    $('#ShippingAddress').removeClass("is-invalid");
    $('#ShippingCity').removeClass("is-invalid");
    $('#ShippingCountry').removeClass("is-invalid");
    $('#ShippingState').removeClass("is-invalid");
    $('#ShippingPincode').removeClass("is-invalid");
    $('#adhar').removeClass("is-invalid");
    $('#pan').removeClass("is-invalid");
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
    if ($('#PrimaryMailID').val() == '') {
        $('#PrimaryMailID').addClass("is-invalid");
        valRes = false;
    }
    if ($('#BillingAddress').val() == '') {
        $('#BillingAddress').addClass("is-invalid");
        valRes = false;
    }
    if ($('#BillingCity').val() == '') {
        $('#BillingCity').addClass("is-invalid");
        valRes = false;
    }
    if ($('#BillingCountry').val() == '') {
        $('#BillingCountry').addClass("is-invalid");
        valRes = false;
    }
    if ($('#BillingState').val() == '') {
        $('#BillingState').addClass("is-invalid");
        valRes = false;
    }
    if ($('#BillingPincode').val() == '') {
        $('#BillingPincode').addClass("is-invalid");
        valRes = false;
    }
    if ($('#ShippingAddress').val() == '') {
        $('#ShippingAddress').addClass("is-invalid");
        valRes = false;
    }
    if ($('#ShippingCity').val() == '') {
        $('#ShippingCity').addClass("is-invalid");
        valRes = false;
    }
    if ($('#ShippingCountry').val() == '') {
        $('#ShippingCountry').addClass("is-invalid");
        valRes = false;
    }
    if ($('#ShippingState').val() == '') {
        $('#ShippingState').addClass("is-invalid");
        valRes = false;
    }
    if ($('#ShippingPincode').val() == '') {
        $('#ShippingPincode').addClass("is-invalid");
        valRes = false;
    }
    lblError.innerHTML = "";
    var allowedFiles = [".pdf"];
    var fileUpload = $('#adhar').val();
    var panfileUpload = $('#pan').val();
    var regex = new RegExp("([a-zA-Z0-9\s_\\.\-:])+(" + allowedFiles.join('|') + ")$");
    if (!regex.test(fileUpload.toLowerCase()) && fileUpload!="") {
        $('#adhar').addClass("is-invalid");
        lblError.innerHTML = "Please upload files having extensions: <b>" + allowedFiles.join(', ') + "</b> only.";
        valRes = false;
    }
    if (!regex.test(panfileUpload.toLowerCase()) && panfileUpload!="") {
        $('#pan').addClass("is-invalid");
        lblError.innerHTML = "Please upload files having extensions: <b>" + allowedFiles.join(', ') + "</b> only.";
        valRes = false;
    }
    return valRes;
}
function toggleCheckbox(element) {
    if (element.checked) {
        $('#ShippingAddress').val($('#BillingAddress').val());
        $('#ShippingAddress1').val($('#BillingAddress1').val());
        $('#ShippingCity').val($('#BillingCity').val());
        $('#ShippingState').val($('#BillingState').val());
        $('#ShippingCountry').val($('#BillingCountry').val());
        $('#ShippingPincode').val($('#BillingPincode').val());
    }
    if (!element.checked) {
        $('#ShippingAddress').val("");
        $('#ShippingAddress1').val("");
        $('#ShippingCity').val("");
        $('#ShippingState').val("");
        $('#ShippingCountry').val("");
        $('#ShippingPincode').val("");
    }
}