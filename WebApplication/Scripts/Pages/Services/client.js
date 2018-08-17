angular.module('dolphinApp')
    .service("ClientService", function ($rootScope) {        
        return {
            get: function () {
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
            },

            add: function (client) {
                console.log("ClientService add fired!")
            },

            update: function (client) {
                console.log("ClientService update fired!")
            },

            selectClient: function (client) {
                this.client = client;
                $rootScope.$emit('select-client-event');
            },

            onClientChange: function (scope, callback) {
                var handler = $rootScope.$on('select-client-event', callback);
                scope.$on('$destroy', handler);
            }
        };
    });