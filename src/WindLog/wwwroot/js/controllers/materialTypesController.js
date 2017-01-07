(function () {
    'use strict';

    angular
        .module('app-materialTypes')
        .controller('materialTypesController', materialTypesController);

    function materialTypesController($http) {
        var vm = this;
        vm.materialTypes = [];
        vm.materialTypeInForm = {};
        vm.errorMessages = '';
        vm.isBusy = true;
        vm.itemsByPage = 10;

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

        vm.addMaterialType = function () {
            vm.materialTypeInForm = {};
        };

        vm.selectRow = function (row) {
            vm.materialTypeInForm = row;
            vm.materialTypeInForm.dateCreated = row.dateCreated;
        };

        vm.newItem = function () {
            vm.materialTypeInForm = {};
            vm.materialTypeInForm.dateCreated = new Date();
        };

        vm.clearItem = function () {
            vm.materialTypeInForm = {};
        };
    }
})();