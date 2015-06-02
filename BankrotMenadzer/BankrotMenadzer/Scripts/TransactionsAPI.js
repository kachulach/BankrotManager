$(document).ready(function (event) {
    
    $("#AddTransaction").on("click", function (event) { AJAX_AddTransaction(event); });
    console.log("Working");

});

function AJAX_AddTransaction(event) {
    
    event.preventDefault();

    console.log($("#tbName"));
    console.log($("#tbName").val());

}