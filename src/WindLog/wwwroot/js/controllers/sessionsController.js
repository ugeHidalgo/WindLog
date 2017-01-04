(function () {
    'use strict';

    angular
        .module('app-sessions')
        .controller('sessionsController', sessionsController);

    function sessionsController($http) {
        var vm = this;
        vm.sessions = [];
        vm.errorMessages = '';
        vm.isBusy = true;

        $http.get('/api/sessions')
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.sessions);
            }, function (error) {
                //Failure
                vm.errorMessages = 'Failed to load sessions: ' + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });
    }
})();