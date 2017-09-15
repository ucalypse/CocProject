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
        performAdminFunction(function() {
            $("#popupContact").css("display", "block");
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
        var memberName = prompt("Enter username");
        var mapPosition = this.getAttribute("data-position");
        var position = parseInt(mapPosition) + 1;
        if (memberName !== null) {
            $.post("/Home/ReserveTarget", { member: memberName, target: position })
                .done(function (data) {
                    location.reload();
                });
        }
        return false;
    });

    $("#clearTargets").click(function () {
        performAdminFunction(function() {
            $.get("/Home/ClearTargets").done(function (data) {
                location.reload();
            });
        });
    });

    function performAdminFunction(onAuthenticationSuccess) {
        var name = prompt("Enter username");
        var password = prompt("Enter Admin Password");
        $.post("/Home/GetAuthentication", { adminName: name, adminPassword: password })
            .done(function (data) {
                if (data) {
                    onAuthenticationSuccess();
                } else {
                    alert("Authentication failed");
                }
            });
    }
});
