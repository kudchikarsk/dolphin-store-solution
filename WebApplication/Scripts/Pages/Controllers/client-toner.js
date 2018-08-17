angular.module('dolphinApp')
    .controller('ClientTonerController', ['ClientService', 'TonerService', function ($clientService, $tonerService) {
        this.all = $tonerService.get();
    }]);