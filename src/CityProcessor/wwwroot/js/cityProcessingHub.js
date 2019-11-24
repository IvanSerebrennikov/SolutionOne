(function (signalR) {
    "use strict";

    var connection = new signalR.HubConnectionBuilder().withUrl("/cityProcessingHub").build();

    connection.on("ReceiveCityProcessingMessage", function (text) {
        console.log(text);

        var alert = `<div class="alert city-processing-alert" role="alert">${text}</div>`;

        $("#cityProcessingInfo").append(alert);
    });

    connection.start().then(function () {
        console.log("cityProcessingHub connected.");
    }).catch(function (err) {
        return console.error(err.toString());
    });
})(signalR);