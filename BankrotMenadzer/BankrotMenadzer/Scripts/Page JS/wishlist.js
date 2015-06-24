$(document).ready(function () {

    $(".remove-wishlist-item").on('click', function (event) {
        var id = $(this).data('id');
        var row = $(this).parent();
        remove_item(id, row);
    });

    $(".buy-wishlist-item").on('click', function (event) {
        var id = $(this).data('id');
        var row = $(this).parent().parent();
        buy_item(id, row);
    });

});


function buy_item(id, row) {
    $.ajax({
        type: 'POST',
        url: 'Wishlist.aspx/AJAX_BuyWishlist',
        data: '{ "id": ' + id + ' }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            success_buy(data);
            row.hide();
        },
        failure: fail_buy
    });
}

function remove_item(id, row) {

    $.ajax({
        type: 'POST',
        url: 'Wishlist.aspx/AJAX_RemoveWishlist',
        data: '{ "id": ' + id + ' }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
            success_remove(data);
            row.hide();
        },
        failure: fail_remove
    });
}

function success_buy(data) {
    console.log(data);
    location.reload();
}

function fail_buy(data) {
    console.log(data);
}

function success_remove(data) {
    console.log(data);
    location.reload();
}

function fail_remove(data) {
    console.log(data);
}