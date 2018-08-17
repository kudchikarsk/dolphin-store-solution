angular.module('dolphinApp')
    .service("ClientService", function () {
        var selected = null;

        this.get = function()
        {
            console.log("ClientService get fired!")

            return [
                {
                    Name: "Dr Strange",
                    Address: "New York",
                    Mobile: "99999999",
                    Email: "strange@gmail.com"
                },
                {
                    Name: "SpiderMan",
                    Address: "New York",
                    Mobile: "99999999",
                    Email: "spiderman@gmail.com"
                }
            ];
        }

        this.add = function (client)
        {
            console.log("ClientService add fired!")
        }

        this.update = function (client)
        {
            console.log("ClientService update fired!")
        }

        this.setSelectedClient = function (client) {
            selected = client;
        }

        this.getSelectedClient = function () {
            return selected;
        }

    });