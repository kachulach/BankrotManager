﻿$(document).ready(function () {
    var today = moment().format('DD.MM.YYYY');

    var from = getUrlParameter("start");
    var to = getUrlParameter("end");
    if (from == null || to == null) {
        from = today;
        to = today;
    }

    $('#calendar-picker').daterangepicker(
    {
        format: 'DD.MM.YYYY',
        startDate: from,
        endDate: to,
        ranges: {
            'Today': [moment(), moment()],
            'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Last 7 Days': [moment().subtract(6, 'days'), moment()],
            'Last 30 Days': [moment().subtract(29, 'days'), moment()],
            'This Month': [moment().startOf('month'), moment().endOf('month')],
            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        }
    },

    function (start, end, label) {
        console.log(start);
        changeData(start.format('DD.MM.YYYY'), end.format('DD.MM.YYYY'));
        //alert("A new date range was chosen: " +  + ' to ' + end.format('DD-MM-YYYY'));
    });

    //initializeData();
});


function initializeData() {

    var now = moment();
    var formattedNow = now.format("DD.MM.YYYY");

    $.ajax({
        type: 'POST',
        url: 'Default.aspx/AJAX_TransactionData',
        data: '{from: "' + formattedNow + '", to: "' + formattedNow + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: setData,
        failure: function (response) {
            alert(response.d);
        }
    });

}

function changeData(from, to) {
    console.log(from);
    console.log(to);
    window.location.href = '?start=' + from + '&end=' + to;
}

function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam) {
            return sParameterName[1];
        }
    }
    return null;
}