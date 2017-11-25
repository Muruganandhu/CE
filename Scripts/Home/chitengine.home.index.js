$(document).ready(function () {
   
    getDAshboardData();
 
});
var getDAshboardData = function () {
    var errorMsg = [];
    var successCall = function (data) {
        alert(data);
        var json = $.parseJSON(data);
            //JSON.parse(data);
        
        var tableHeaders='';
        var colHeaders = [];
        var tableRows='';
        //$.each(json.columns, function (i, val) {
        //    tableHeaders += "<th>" + val + "</th>";
        //});       
            for (var key in json[0]) {
                tableHeaders += "<th>" + key + "</th>";
                colHeaders.push(key);
                console.log(key); // here is your column name you are looking for
            }
            for (var i = 0; i < json.length; i++) {
                tableRows += '<tr>';
                for (var item in json[0]) {
                    var tempvalue = json[i][item] == null ? 0 : json[i][item];
                    tableRows += "<td>" + tempvalue + "</td>";
                }
                tableRows += '</tr>';
            }

        $("#tableDiv").empty();
        $("#tableDiv").append('<table id="displayTable" class="display" cellspacing="0" width="100%"><thead><tr>' + tableHeaders + '</tr></thead><tbody>' + tableRows + '</tbody></table>');


        //$('#displayTable').DataTable({
        //    "order": [1, "asc"],

        //});



        $('#displayTable').DataTable();
    };
    var errorCall = function (errorData) {
        console.table(errorData);
    };
    ajaxCall('/Home/GetHomeDashBoard', null, 'POST', successCall, errorCall);
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