$(function () {
        var ClanMember = function(identifier, playerTag, townHallLevel) {
            this.name = ko.observable(identifier);
            this.playerTag = playerTag;
            this.townHallLevel = townHallLevel;
        };
    
    $.getJSON('/TownHall/GetFilteredList') 
        .done(function (response) {
            var wahwah = [];
            $.each(response.Members,
                function(i,k) {
                    wahwah.push(new ClanMember(k.Name, k.PlayerTag, k.TownHallLevel));
                    alert(wahwah[i].name);
                }); 
            
            ko.applyBindings(response);
        });
    $("#beginnerTable").hide();
});

var display = (function () {
    $("#beginnerTable").show("slow");
});
