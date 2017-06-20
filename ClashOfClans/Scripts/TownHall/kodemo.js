$(function () {
    var result = $.getJSON('/TownHall/GetFilteredList')
        .done(function(response) {
            ko.applyBindings(response);
        });
    viewModel = result;
    $("#beginnerTable").hide();
    $("#memberInput").onkeydown = "search()";
});

var display = (function () {
    $("#beginnerTable").show("slow");
    
});
var search = function() {
    viewModel.filteredItems = ko.computed(function () {
        var filter = this.filter().toLowerCase();
        if (!filter) {
            return this.items();
        } else {
            return ko.utils.arrayFilter(this.items(), function (item) {
                return ko.utils.stringStartsWith(item.name().toLowerCase(), filter);
            });
        }
    }, viewModel);
}
