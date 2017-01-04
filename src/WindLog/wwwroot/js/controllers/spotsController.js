(function () {
    'use strict';

    angular
        .module('app-spots')
        .controller('spotsController', spotsController);

    function spotsController($http) {
        var vm = this;
        vm.spots = [];
        vm.errorMessages = '';
        vm.isBusy = true;

        $http.get('/api/spots')
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.spots);
            }, function (error) {
                //Failure
                vm.errorMessages = 'Failed to load spots: ' + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });
    }
})();