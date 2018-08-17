angular.module('dolphinApp')
    .service("TonerService", function () {

        this.get = function (client) {
            console.log("TonerService get fired!")

            return [
                { Name: "Epson L800" }
            ];
        }

        this.add = function (client, toner) {
            console.log("TonerService add fired!")
        }

        this.update = function (client,toner) {
            console.log("TonerService update fired!")
        }

    });