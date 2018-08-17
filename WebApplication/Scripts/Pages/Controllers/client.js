angular.module('dolphinApp')
    .controller("ClientController", ['ClientService', function ($clientService) {
        this.all = $clientService.get();
        this.newClient = {};

        this.addNewClient = function () {
            var client = this.newClient;
            this.newClient = {}
            $clientService.add(client);
            this.all.push(client);
        }

        this.select = function (client) {
            $clientService.setSelectedClient(client);
        }

    }]);