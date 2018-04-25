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

    $("#submitButton").click(function () {
        var text = $("#videoDescription").val();
        var address = $("#videoLink").val();
        var label = $("#videoLinkLabel").val();

        $.post("/Home/SaveVideo", { url: address, description : text, title : label })
            .done(function (data) {
                $("#VideoAdd").css("display", "none");
                location.reload();
            });
    });
});