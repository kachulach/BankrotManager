$(document).ready(function () {
    console.log("BMChart imported!");
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
        this.parentElement = $(canvasID).parent();
        switch (chartType) {
            case 'pie': this.chart = new Chart(this.context).Pie({}, this.options); break;
                //TODO Implement Bar charts
            case 'bar': this.chart = new Chart(this.context).Bar("test"); break;
        }


        if (this.hasLegend) {
            this.parentElement.find(".chart-legend").html(this.generateLegend(this.chartData));
        }
        this.addData(this.data);
    }

    this.addData = function (jsonData) {
        
        var objs = JSON.parse(jsonData);

        
        //TODO check 
        for (j = 0; j < objs.length; j++) {
            var obj = objs[j];
            var index = -1;
            //Find if there already exist a label with that name and get the index
            for (i = 0; i < this.chart.segments.length; i++) {
                if (this.chart.segments[i].label == obj.label) {
                    index = i;
                    break;
                }
            }
            //If there is a label
            if (index != -1) {
                var newValue = this.chart.segments[i].value + obj.value;
                this.chart.segments[index].value = newValue;
            }
                //If there isn't a label, create one
            else {
                var objColor = getColor(this.chart.segments.length);
                obj.color = objColor;
                this.chart.addData(obj);
            }
            this.refresh(obj);
        }
    }


    this.addTransaction = function (jsonObj) {
        
        var obj = {
            label: jsonObj.category,
            value: parseInt(jsonObj.amount)
        }
        var index = -1;

        //Find if there already exist a label with that name and get the index
        for (i = 0; i < this.chart.segments.length; i++) {
            if (this.chart.segments[i].label == obj.label) {
                index = i;
                break;
            }
        }

        //If there is a label
        if (index != -1) {
            var newValue = this.chart.segments[i].value + obj.value;
            this.chart.segments[index].value = newValue;
        }
            //If there isn't a label, create one
        else {
            var objColor = getColor(this.chart.segments.length);
            obj.color = objColor;
            this.chart.addData(obj);
        }
        this.refresh(obj);
    }

    this.refresh = function(data) {
        this.chart.update();
        //console.log("test11");
        this.data = this.convertChartDataToRaw();
        this.chartData = this.convertDataToChartData(this.data);

        if (this.hasLegend) {
            this.parentElement.find(".chart-legend").html(this.generateLegend(this.chartData));
        }
    }

    this.convertDataToChartData = function(data) {

        //var objs = JSON.parse(data);
        //console.log(objs);
        var chartArray = Array();

        //There might be a better choice for predefined colors
        var colors = randomColor({
            count: data.length,
        });

        for (i = 0; i < data.length; i++) {
            var item = data[i];
            var color = getColor(i);

            chartArray.push({
                label: item.category,
                value: item.cost,
                color: color
            });
        }
        return chartArray;
    }

    this.convertChartDataToRaw = function () {


        var data = this.chart.segments;
        var arr = Array();
        for (i = 0; i < data.length; i++) {
            var segment = data[i];
            arr.push({ category: segment.label, cost: segment.value });
        }
        return arr;
    }


    this.generateLegend = function(data) {

        if (data == null) return;

        var total = 0;
        for (var i = 0, n = data.length; i < n; ++i) {
            total += data[i].value;
        }

        var html = '<ul style="list-style-type: none">';

        for (i = 0; i < data.length; i++) {
            var item = data[i];
            var percent = item.value / total;
            html += '<li><div style="display: inline-block; width: 60px; height:12px; background-color: ' + item.color + '"></div>' + item.label + ' (' + Math.round(percent * 10000)/100 + '%)</li>';
        }

        html += '</ul>';
        return html;
    }

    this.init();
    return this;
}


//This should be themable
function getColor(number) {

    var colors = ["#98f4cd",
                    "#bcee68",
                    "#00adff",
                    "#f56560",
                    "#02659a",
                    "#FFCCFF"
    ];
    return colors[number];


}