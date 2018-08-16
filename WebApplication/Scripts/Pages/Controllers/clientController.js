angular.module('dolphinApp')
    .controller("ClientController", function ($scope) {
        $scope.clients = [
            {
                Name: "Dr Strange",
                Address: "New York",
                Mobile: "99999999",
                Email:"strange@gmail.com"
            },
            {
                Name: "SpiderMan",
                Address: "New York",
                Mobile: "99999999",
                Email: "spiderman@gmail.com"
            }
        ];

    });