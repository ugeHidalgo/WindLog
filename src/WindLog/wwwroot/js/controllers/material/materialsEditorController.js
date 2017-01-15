(function () {
    'use strict';

    angular.module('app-materials')
    .controller('MaterialsEditorController', materialsEditorController);

    function materialsEditorController($routeParams,$http) {
        var vm = this, url,
            year, month, day;

        vm.id = $routeParams.materialId;
        vm.errorMessage = '';
        vm.isBusy = true;
        vm.material = {};                

        $http.get('/api/materials/' + vm.id)
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.material);
                vm.material.datePurchased = parseDate(vm.material.datePurchased);
                vm.material.dateCreated = parseDate(vm.material.dateCreated);                
            }, function (error) {
                //Failure
                vm.errorMessage = 'Failed to load material with id ' + vm.id + ' : ' + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        vm.newItem = function () {
            vm.material = {};
            vm.id = 0;
            vm.materialId = 0;
            vm.material.dateCreated = new Date();
            vm.material.datePurchased = new Date();
        };

        vm.clearSelectedItem = function () {
            vm.material = {};
        };
    }
})();