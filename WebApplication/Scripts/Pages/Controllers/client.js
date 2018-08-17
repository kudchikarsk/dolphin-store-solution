angular.module('dolphinApp')
    .controller("ClientController", ['$scope', 'ClientService', function ($scope, $clientService) {
        $scope.all = $clientService.get();
        $scope.newClient = {};

        $scope.addNewClient = function () {
            var client = $scope.newClient;
            $scope.newClient = {}
            $clientService.add(client);
            $scope.all.push(client);
        }

        $scope.select = function (client) {
            $clientService.selectClient(client);
        }

    }]);