(function () {
    'use strict';

    angular
        .module('app-materials')
        .controller('materialsController', materialsController);

    function materialsController($http) {
        var vm = this;
        vm.materials = [];
        vm.errorMessages = '';
        vm.isBusy = true;

        $http.get('/api/materials')
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.materials);
            }, function (error) {
                //Failure
                vm.errorMessages = 'Failed to load materials: ' + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });
    }
})();