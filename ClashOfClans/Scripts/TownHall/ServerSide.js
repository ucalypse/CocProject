$(function () {
    
    function MemberModel(response) {
        var self = this;
        self.name = ko.observable(response.Name);
        self.townHallLevel = response.TownHallLevel;
        self.clanTag = response.ClanTag;
      
    }
    function MemberViewModel() {
        var self = this;
        self.members = ko.observableArray();
        $.getJSON("Home/ActivityData", function (data) {
            $.each(data, function () {
                self.members.push(new MemberModel(data));
            });
        });
    }

    ko.applyBindings(new MemberViewModel());
    $("#beginnerTable").hide();
});

var display = (function () {
    $("#beginnerTable").show("slow");
});
