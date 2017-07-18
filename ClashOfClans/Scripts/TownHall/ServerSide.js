$(function () {
    $.getJSON('/TownHall/GetFilteredList')
        .done(function (response) {
            ko.applyBindings(response);
        });
    $("#beginnerTable").hide();
});

var display = (function () {
    $("#beginnerTable").show("slow");
});
