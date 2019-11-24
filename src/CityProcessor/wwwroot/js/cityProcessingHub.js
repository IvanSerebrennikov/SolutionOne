(function (signalR) {
    "use strict";

    var connection = new signalR.HubConnectionBuilder().withUrl("/cityProcessingHub").build();

    connection.on("ReceiveCityProcessingMessage", function (message) {
        console.log(message);

        var text = `<h6>${message.headText}</h6><p>${message.actionText}</p>`;

        var $alert =
            $('<div class="alert city-processing-alert" role="alert"></div>');

        $alert.html(text);

        if (message.color) {
            $alert.css("background-color", message.color);
        }

        $("#cityProcessingInfo").append($alert);
    });

    connection.start().then(function () {
        console.log("cityProcessingHub connected.");
    }).catch(function (err) {
        return console.error(err.toString());
    });
})(signalR);