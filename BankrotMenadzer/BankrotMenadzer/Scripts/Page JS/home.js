var chart1;
var chart2;

var fields = {};

$(document).ready(function () {

    fields.name = $("#name");
    fields.amount = $("#amount");
    fields.category = $("#category");
    fields.comment = $("#comment");

    $("#transaction-add").on('click', function (event) {
        if (!$(this).hasClass('disabled')) {
            post_transaction(event, 1);
        }
    });


    $("#transaction-remove").on('click', function (event) {
        if (!$(this).hasClass('disabled')) {
            post_transaction(event, 2);
        }
    });


    $("#transaction-wishlist").on('click', function (event) {
        if (!$(this).hasClass('disabled')) {
            post_transaction(event, 3);
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
        fields.name.val("");
        fields.amount.val("");
        fields.category.html("Choose category <span class=\"caret\"></span>");
        fields.category.val("0");
        fields.comment.val("");
        event.preventDefault();
    });

    var testData = [

        {
            category: 'Groceries',
            cost: 500
        },
        {
            category: 'Bills',
            cost: 1200
        }, {
            category: 'Luxuries',
            cost: 200
        },
    ];

    var testData2 = [

        {
            category: 'Pool stuff',
            cost: 2133
        },
        {
            category: 'Torrents',
            cost: 45334
        }, {
            category: 'Hard Disk C',
            cost: 10054
        },
    ];

    chart1 = new BMChart("#chart_weekSpendings", "pie", testData, null, true);
    chart2 = new BMChart("#chart_monthlySpendings", "pie", testData2, null, true);


});

function post_transaction(event, type) {

    event.preventDefault();

    name = $("#name").val();
    amount = parseInt($("#amount").val());
    //TODO Fix this
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
        success: OnSuccess,
        failure: function (response) {
            alert(response.d);
        }
    });

    //Update chart instantly
    function OnSuccess(response) {
        //jsonObj = JSON.parse(response.d);
        //chart1.addTransaction(jsonObj);
        //Maybe loading indicator?
    }
}