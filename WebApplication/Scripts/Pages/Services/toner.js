angular.module('dolphinApp')
    .service("TonerService", function () {
        return {
            get: function (client) {
                console.log("TonerService get fired!" + JSON.stringify(client))

                return [
                    { Name: "Epson L800" }
                ];
            },

            add : function (client, toner) {
                    console.log("TonerService add fired!")
                },

            update : function (client, toner) {
                    console.log("TonerService update fired!")
                }
        }
    });