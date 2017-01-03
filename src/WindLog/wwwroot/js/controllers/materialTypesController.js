(function () {
    'use strict';

    angular
        .module('app-materialTypes')
        .controller('materialTypesController', materialTypesController);

    function materialTypesController($http) {
        var vm = this;
        vm.materialTypes = [];
        vm.errorMessages = '';
        vm.isBusy = true;

        $http.get('/api/materialtypes')
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.materialTypes);
            }, function (error) {
                //Failure
                vm.errorMessages = 'Failed to load material types: ' + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });
    }
})();