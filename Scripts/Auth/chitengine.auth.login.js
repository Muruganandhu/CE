$(document).ready(function () {
    titlenotifier.max(9);
    $("input:text:visible:first").focus();
    $('#btnLogin').on("click", function () {
        loginFunction();
    });
});
var loginFunction = function () {
    var errorMsg = [];
    var successCall = function (data) {        
        if (data.IsSuccess) {
            location.href = data.IsAdmin ? '../Home/Index' : '../Home/Index';
        } else {
            errorMsg.push(data.ErrorMessage);
            showErrorMessage(errorMsg);
        }
    };
    var errorCall = function (errorData) {
        console.table(errorData);
    };
    checkInputElementValid(errorMsg, '#username');
    checkInputElementValid(errorMsg, '#password');
    var Jsondata = {    
            uname: $('#username').val(),
            pword: $('#password').val(),
            isCustomer:true     
    }
    if (errorMsg.length === 0) {
        ajaxCall('/Auth/LoginAction', Jsondata, 'POST', successCall, errorCall);
    } else {
        showErrorMessage(errorMsg);
    }
};
var showErrorMessage = function (msg) {
    var statusMessage = '';
    for (var i = 0; i < msg.length; i++) {
        statusMessage += '<span>' + msg[i] + '</span>';
        statusMessage += (i === msg.length) ? '' : '<br/>';
        titlenotifier.add();
    }
    $('#errorMsg').show();
    $('#errorMsg').html(statusMessage);
};
var checkInputElementValid = function (msg, inputid) {
    //alert($(inputid).val());
    var inputValue = $(inputid).val().trim();
    if (inputValue === null || inputValue === undefined || inputValue === ' ' || inputValue === '' || !inputValue || inputValue.length === 0) {
        var errorMsg = $(inputid).attr('data-error-msg');
        msg.push(errorMsg);
    };
};
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