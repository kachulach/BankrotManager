$(document).ready(function () {

    $("#transaction-add").on('click', function (event) {
        post_transaction(event, 1);
    });

});

function post_transaction(event, type) {

    event.preventDefault();

    name = $("#name").val();
    amount = $("#amount").val();
    //TODO Fix this
    category = "CAT";// $("#category").val();
    comment = $("#comment").val();

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

    function OnSuccess(response) {
        console.log(response);
    }
}