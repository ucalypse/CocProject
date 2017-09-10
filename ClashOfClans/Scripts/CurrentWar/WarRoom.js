$(function () {
    $.getJSON('/Home/ConvertedDateTime')
        .done(function (response) {
            var countDownDate = new Date(response).getTime();
            var x = setInterval(function () {

                    var now = new Date();
                    var nowUtc = new Date(now.getUTCFullYear(), now.getUTCMonth(), now.getUTCDate(), now.getUTCHours(), now.getUTCMinutes(), now.getUTCSeconds());

                    var distance = countDownDate - nowUtc;

                    var seconds = Math.floor((distance / 1000) % 60);
                    var minutes = Math.floor((distance / 1000 / 60) % 60);
                    var hours = Math.floor((distance / (1000 * 60 * 60)));

                    $("#renderTime").html(
                        (hours) + "h " + minutes + "m " + seconds + "s ");
                    if (minutes < 30) {
                        $("#renderTime").css("color", "red");
                    }
                    if (distance < 0) {
                        clearInterval(x);
                        $("#renderTime").html("Final Score");
                    }
                },
                1000);
        });
    $("#button").click(function () {
        var name = prompt("Enter username");
        var password = prompt("Enter Admin Password");
        $.post("/Home/GetAuthentication", { adminName: name, adminPassword: password })
            .done(function (data) {
                if (data) {
                    $("#popupContact").css("display", "block");
                } else {
                    alert("Authentication failed");
                }
            });
    });

    $("#closeButton").click(function () {
        $("#popupContact").css("display", "none");
    });

    $("#submitButton").click(function () {
        var war = $("#warPlan").val();
        var member = $("#memberName").val();
        $.post("/Home/SendWarPlan", { memberName: member, warPlan: war })
            .done(function (data) {
                $("#displayMemberName").html(member + "<br />");
                $("#displayWarPlan").html(war);
                $("#popupContact").css("display", "none");
            });
    });
    $(".warImages").click(function (event) {
        event.preventDefault();
        var memberName = prompt("Enter your member name");
        var temp = this.getAttribute("data-position");
        var position = parseInt(temp) + 1;
        $.post("/Home/ReserveTarget", { member: memberName, target: position })
            .done(function(data) {
                alert("wah");
            });
        return false;
    });
});