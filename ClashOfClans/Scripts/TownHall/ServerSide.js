$(function () {
    function MemberProperties(name) {
        var self = this;
        self.name = ko.observable(name);
    }
    function MemberViewModel() {
        var self = this;

       self.memberList = $.getJSON('/TownHall/GetFilteredList')
            .done(function(response) {
               ko.applyBindings(response);
            });

        self.seats = ko.observableArray([
            new SeatReservation("Steve", self.availableMeals[0]),
            new SeatReservation("Bert", self.availableMeals[0])
        ]);
    }
    
    $("#beginnerTable").hide();
});

var display = (function () {
    $("#beginnerTable").show("slow");
});
