var chart1;
var chart2;

$(document).ready(function (event) {
    
    $("#AddTransaction").on("click", function (event) { AJAX_AddTransaction(event); });
    console.log("Working");
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

function AJAX_AddTransaction(event) {
    
    event.preventDefault();

    $.ajax({
        type: "POST",
        url: "Default.aspx/AJAX_AddTransaction",
        data: null,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Success_AddTransaction,
        failure: function (response) {
            alert(response.d);
        }
    });

}

function Success_AddTransaction(response) {
    
    chart1.addData(response.d);

}

function UpdateCharts() {

    

}