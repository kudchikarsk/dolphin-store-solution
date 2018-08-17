angular.module('dolphinApp')
    .controller('ClientTonerController', ['$scope', 'ClientService', 'TonerService', function ($scope, $clientService, $tonerService) {
        $scope.client = null;
        $scope.all = [];
        $clientService.onClientChange($scope, function () {
            $scope.client = $clientService.client;
            $scope.all = $tonerService.get($scope.client);
        });
    }]);