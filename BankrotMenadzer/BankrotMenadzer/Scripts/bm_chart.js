$(document).ready(function () {
    
});


///Constructor for BMChart object.
///
///canvasID - ID of the canvas you want to put the chart in to. Must start with #
///chartType - string [ 'pie', 'bar' ]
///data - must be an array of objects of type { category: 'String', cost: 'number' }
///hasLegend - should a legend be put in the .chart-legend div.
var BMChart = function (canvasID, chartType, data, options, hasLegend) {

    this.parentElement = null;
    this.canvasID = canvasID;
    this.chartType = chartType;
    this.chart = null;
    this.data = data;
    this.chartData = null;
    this.hasLegend = hasLegend;
    this.options = {
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

    this.init = function() {
        this.context = $(canvasID)[0].getContext('2d');
        this.chartData = this.convertDataToChartData(this.data);
        this.parentElement = $(canvasID).parent();
        //console.log("Chart to: " + canvasID);
        switch (chartType) {
            case 'pie': this.chart = new Chart(this.context).Pie(this.chartData, this.options); break;
                //TODO Implement Bar charts
            case 'bar': this.chart = new Chart(this.context).Bar("test"); break;
        }


        if (this.hasLegend) {
            this.parentElement.find(".chart-legend").html(this.generateLegend(this.chartData));
        }
    }

    this.addData = function (jsonData) {
        
        var obj = JSON.parse(jsonData);
        var index = -1;
        for (i = 0; i < this.chart.segments.length; i++) {
            if (this.chart.segments[i].label == obj.label) {
                index = i;
                break;
            }
        }
        if (index != -1) {
            this.chart.segments[index].value = obj.value;
            this.chart.update();
        }
        else {
            this.chart.addData(obj);
        }
        console.log(this.chart);
    }

    this.refresh = function() {
        this.chart.update();
    }

    this.convertDataToChartData = function(data) {

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


    this.generateLegend = function(data) {

        var html = '<ul style="list-style-type: none">';

        for (i = 0; i < data.length; i++) {
            var item = data[i];
            html += '<li><div style="display: inline-block; width: 60px; height:12px; background-color: ' + item.color + '"></div>' + item.label + '</li>';
        }

        html += '</ul>';
        return html;
    }

    this.init();
    return this;
}