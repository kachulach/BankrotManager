var chart1;
var chart2;

var fields = {};

$(document).ready(function () {

    fields.name = $("#name");
    fields.amount = $("#amount");
    fields.category = $("#category");
    fields.comment = $("#comment");
    fields.success = $("#message-success");

    $("#transaction-add").on('click', function (event) {
        if (!$(this).hasClass('disabled')) {
            post_transaction(event, 1);
            clearData();
        }
    });


    $("#transaction-remove").on("click", function (event) {
        if (!$(this).hasClass("disabled")) {
            post_transaction(event, 2);
            clearData();
        }
    });


    $("#transaction-wishlist").on('click', function (event) {
        if (!$(this).hasClass('disabled')) {
            post_transaction(event, 3);
            clearData();
        }
    });

    $(".dropdown li a").click(function (event) {
        event.preventDefault();
        var data = $(this).data('id');
        var text = $(this).text();
        $(this).parents(".dropdown").find('.btn').text(text);
        $(this).parents(".dropdown").find('.btn').val(data);
        $(this).parents(".dropdown").find('.btn').focus();
    });

    $("#transaction-clear-form").on('click', function (event) {
        clearData();
        event.preventDefault();
    });

    initializeData();

});

function clearData() {
    fields.name.val("");
    fields.amount.val("");
    fields.category.html("Choose category <span class=\"caret\"></span>");
    fields.category.val("0");
    fields.comment.val("");
}

function initializeData() {

    $.ajax({
        type: 'POST',
        url: 'Default.aspx/AJAX_DailyStats',
        data: '{ "type": 1 }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: initSavings,
        failure: function (response) {
            showError(response.d);
        }
    });

    $.ajax({
        type: 'POST',
        url: 'Default.aspx/AJAX_DailyStats',
        data: '{ "type": 2 }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: initSpendings,
        failure: function (response) {
            showError(response.d);
        }
    });

}

function initSavings(data) {

    chart1 = new BMChart("#chart_weekSpendings", "pie", data.d, null, true);

}

function initSpendings(data) {
    chart2 = new BMChart("#chart_monthlySpendings", "pie", data.d, null, true);
}

function post_transaction(event, type) {

    event.preventDefault();
    waitingSuccess();

    name = $("#name").val();
    amount = parseInt($("#amount").val());

    intType = parseInt(type);
    if (intType == 2) {
        amount *= -1;
    }

    category = $("#category").val();
    category_name = $("#category").text();
    comment = $("#comment").val();

    if (category == 0) {
        category_name = "Non categorized";
    }

    var transaction = {
        category: category_name,
        amount: amount
    }
    

    //Savings
    if (type == '1' || type == 1) {
        chart1.addTransaction(transaction);
    }

    //Spendings
    if (type == '2' || type == 2) {
        chart2.addTransaction(transaction);
    }


    $.ajax({
        type: 'POST',
        url: 'Default.aspx/AJAX_AddTransaction',
        data: '{type: "' + type + '", name: "' + name + '", amount: "' + amount + '", category: "' + category + '", comment: "' + comment + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        failure: function (response) {
            showError(response.d);
        }
    });

    //Update chart instantly
    function onSuccess(response) {
        //jsonObj = JSON.parse(response.d);
        //chart1.addTransaction(jsonObj);
        //Maybe loading indicator?
        showSuccess();
        //console.log(response);
    }
}

//Success/Error messages

function waitingSuccess() {
    if (fields.success.hasClass('hidden')) {
        fields.success.removeClass('hidden');
    }

    fields.success.text("Adding transaction...");
}

function showSuccess() {
    if (fields.success.hasClass('hidden')) {
        fields.success.removeClass('hidden');
    }

    fields.success.text("Success!");
    setTimeout(function () {
        hideSuccess();
    }, 3000);
}

function showError(error) {
    if (fields.success.hasClass('hidden')) {
        fields.success.removeClass('hidden');
    }

    fields.success.text(error);
    setTimeout(function () {
        hideSuccess();
    }, 3000);
}

function hideSuccess() {
    if (!fields.success.hasClass('hidden')) {
        fields.success.addClass('hidden');
    }
}