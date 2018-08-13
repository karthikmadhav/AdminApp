var errorMsg = {
    roleSubmitError: 'An error occurred while adding new role.',
    privilegeSubmitError: 'An error occurred while adding new role.'
}
function ShowErrorMsg(msg) {
    $("#dvErrorMsg").show();
    $("#dvErrorMsg").text(msg);
}

function ClearErrorMsg() {
    $("#dvErrorMsg").hide();
    $("#dvErrorMsg").empty();
}
$(document).ready(function () {
    $("#dvErrorMsg").hide();
});