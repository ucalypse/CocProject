$(function () {
    var ClanMember = function() {
        this.name = ko.observable();
        this.playerTag;
        this.townHallLevel;
    };
    wahwah = [];
    $.getJSON('/TownHall/GetFilteredList')
        .done(function (response) {
            $.each(response.Members,
                function(i,k) {
                    wahwah.push(new ClanMember()
                        .name(k.Name)
                        .playerTag = k.PlayerTag
                        .townHallLevel = k.TownHallLevel
                    );
                });
            
            ko.applyBindings(response);
        });
    alert(wahwah);
    $("#beginnerTable").hide();
});

var display = (function () {
    $("#beginnerTable").show("slow");
});
