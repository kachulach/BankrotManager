var currentFunds;

$(document).ready(function () {

    int_funds = parseInt($("#lbl_funds").text().split(":")[1].trim());
    int_saved_funds = parseInt($("#lbl_saved_funds").text().split(":")[1].trim());

    currentFunds = {
        funds: int_funds,
        saved_funds: int_saved_funds
    }

    update_funds(int_funds);
    update_save_funds(int_saved_funds);

});

function update_funds(funds) {
    $("#lbl_funds").text("Funds: " + funds);
}

function update_save_funds(funds) {
    $("#lbl_saved_funds").text("Saved funds: " + funds);
}

function update_all_funds() {
    $("#lbl_funds").text("Funds: " + currentFunds.funds);
    $("#lbl_saved_funds").text("Saved funds: " + currentFunds.saved_funds);
}