$(function () {
    $("#videoButton").click(function () {
        var name = prompt("Enter username");
        var password = prompt("Enter Admin Password");
        $.post("/Home/GetAuthentication", { adminName: name, adminPassword: password })
            .done(function (data) {
                if (data) {
                    $("#VideoAdd").css("display", "block");
                } else {
                    alert("Authentication failed");
                }
            });
    });

    $("#closeButton").click(function () {
        $("#VideoAdd").css("display", "none");
    });
});