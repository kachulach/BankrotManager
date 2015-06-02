$(document).ready(function () {

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


    putPieChart("#chart_weekSpendings", testData);

});

function putBarChart(canvasID, data) {
    var canvas = $(id)[0];
    var ctx = canvas.getContext("2d");
}

function putPieChart(canvasID, data) {
    
    var canvas = $(canvasID)[0];
    var ctx = canvas.getContext("2d");

    var options = {
        //Boolean - Whether we should show a stroke on each segment
        segmentShowStroke: true,

        //String - The colour of each segment stroke
        segmentStrokeColor: "#fff",

        //Number - The width of each segment stroke
        segmentStrokeWidth: 2,

        //Number - The percentage of the chart that we cut out of the middle
        percentageInnerCutout: 50, // This is 0 for Pie charts

        //Number - Amount of animation steps
        animationSteps: 100,

        //String - Animation easing effect
        animationEasing: "easeOutBounce",

        //Boolean - Whether we animate the rotation of the Doughnut
        animateRotate: true,

        //Boolean - Whether we animate scaling the Doughnut from the centre
        animateScale: false,
    }

    var chartData = convertDataToChartData(data);
    var myPieChart = new Chart(ctx).Pie(chartData, options);
}

function convertDataToChartData(data) {

    var chartArray = Array();

    //There might be a better choice for predefined colors
    var colors = randomColor({
        count: data.length,
    });

    for (i = 0; i < data.length; i++) {
        var item = data[i];
        var color = colors[i];

        chartArray.push({
            label: item.category,
            value: item.cost,
            color: color
        });
    }
    return chartArray;
}