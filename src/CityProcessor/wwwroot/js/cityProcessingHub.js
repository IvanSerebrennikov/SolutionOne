(function (signalR) {
    "use strict";

    var connection = new signalR.HubConnectionBuilder().withUrl("/cityProcessingHub").build();

    connection.on("ReceiveCityProcessingMessage", function (text) {
        console.log(text);
    });

    connection.start().then(function () {
        console.log("cityProcessingHub connected.");
    }).catch(function (err) {
        return console.error(err.toString());
    });
})(signalR);