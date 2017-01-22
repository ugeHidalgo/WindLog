(function () {
    'use strict';

    angular
        .module('app-spots')
        .controller('spotsController', spotsController);

    function spotsController($http, Notification) {
        var vm = this;
        vm.spots = [];
        vm.errorMessages = '';
        vm.isBusy = true;
        vm.itemsByPage = 10;

        $http.get('/api/spots')
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.spots);
            }, function (error) {
                //Failure
                vm.errorMessages = 'Failed to load spots: ' + error;
                Notification.error('Failed to load spots !');
            })
            .finally(function () {
                vm.isBusy = false;
            });
    }
})();