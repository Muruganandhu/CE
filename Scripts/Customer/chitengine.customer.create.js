$(document).ready(function () {    
    $("input:text:visible:first").focus();
    $('#btnCreate').on("click", function () {
        createChit();
    });
});

var createChit = function ()
{
    var Jsondata = {
        cname: $('#ChitName').val(),
        cmonth: $('#ChitMonth').val(),
        camount: $('#ChitAmount').val(),
        bamount: $('#BeetAmount').val(),
        //isCustomer: true
    }

    //alert(document.getElementById("ChitName").value);
    //alert(document.getElementById("ChitMonth").value);
    //alert(document.getElementById("ChitAmount").value);
    //alert(document.getElementById("BeetAmount").value);
    
    //document.getElementById("latbox-hidden").value
    var successCall = function (data) {
        alert("success");
    };
    var errorCall = function (errorData) {
        alert("fail");
    };
    ajaxCall('/Customer/CreateChitDB', Jsondata, 'POST', successCall, errorCall);
}

var ajaxCall = function (url, requestData, httpverb, successCallback, errorCallback) {
    var jsonData = null;
    if (requestData !== null && requestData !== undefined) {
        jsonData = JSON.stringify(requestData);
    }
    $.ajax({
        url: url,
        type: httpverb,
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus, xhr) {
            if (successCallback && successCallback !== undefined) {
                successCallback(data);
            }
        },
        error: function (xhr, textStatus, errorThrown) {
            if (errorCallback && errorCallback !== undefined) {
                errorCallback(xhr);
            }
        }
    });
};