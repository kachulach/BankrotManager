var fields = {};

$(document).ready(function () {

    fields.success = $("#message-success");

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


    $('.removeTransaction').on("click", function (event) {
        var row = $(this);
        var id = $(this).data("id");
        waitingSuccess();
        $.ajax({
            type: 'POST',
            url: 'History.aspx/AJAX_removeTransaction',
            data: '{transaction_id: "' + id +'"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                row.parent().hide();
                showSuccessRemove(data);
            },
            failure: function (response) {
                showError(response.d);
            }
        });

    });


   

    //initializeData();
});


function result() {
    console.log("Deleted");
}

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


//Success/Error messages

function waitingSuccess() {

    fields.success.text("Removing transaction...");

    if (!fields.success.hasClass('alert-info')) {
        fields.success.addClass('alert-info');
    }

    if (fields.success.hasClass('hidden')) {
        fields.success.removeClass('hidden');
    }
}

function showSuccessRemove(data) {
    jsonObj = JSON.parse(data.d);
    console.log(jsonObj);
    if (jsonObj.category == "Zasteda") {
        currentFunds.funds -= jsonObj.amount;
        currentFunds.saved_funds += jsonObj.amount;
    } else {
        currentFunds.funds -= jsonObj.amount;
    }
    update_all_funds();

    if (!fields.success.hasClass('hidden')) {
        fields.success.addClass('hidden');
    }

    fields.success.text("Success!");

    if (fields.success.hasClass('alert-info')) {
        fields.success.removeClass('alert-info');
    }
    fields.success.addClass('alert-success');
  
    fields.success.removeClass('hidden');
 

    setTimeout(function () {
        hideSuccess();
    }, 3000);
}

function showError(error) {

    if (!fields.success.hasClass('hidden')) {
        fields.success.addClass('hidden');
    }

    fields.success.text(error);

    if (!fields.success.hasClass('alert-info')) {
        fields.success.removeClass('alert-info');
    }
    fields.success.addClass('alert-danger');

    fields.success.removeClass('hidden');

    setTimeout(function () {
        hideSuccess();
    }, 3000);
}

function hideSuccess() {
    if (!fields.success.hasClass('hidden')) {
        fields.success.addClass('hidden');
    }

    if (fields.success.hasClass('alert-info')) {
        fields.success.removeClass('alert-info');
    }

    if (fields.success.hasClass('alert-success')) {
        fields.success.removeClass('alert-success');
    }

    if (fields.success.hasClass('alert-danger')) {
        fields.success.removeClass('alert-danger');
    }
}