$(function () {
    var ClanMember = {
        name : ko.observable(),
        playerTag: ko.observable(),
        townHallLevel: ko.observable()
    };
    var wahwah = [];
    $.getJSON('/TownHall/GetFilteredList')
        .done(function (response) {
            $.each(response.Members,
                function(i,k) {
                    ClanMember.name = k.Name;
                    ClanMember.playerTag=k.PlayerTag;
                    ClanMember.townHallLevel=k.TownHallLevel;
                    wahwah.push(ClanMember);
                    i++;
                });
            ko.applyBindings(response);
        });
    
    $("#beginnerTable").hide();
});
var filterResults = function() {
    $.each($('#beginnerTable'),
        function(i, k) {
            if (k === i) {
                alert("wah");
            }
        });
    alert("You called filter results");
};
var display = (function () {
    $("#beginnerTable").show("slow");
});
