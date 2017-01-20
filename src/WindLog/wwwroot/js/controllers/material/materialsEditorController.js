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

        vm.materialStates = [{
            id: 0,
            name: 'Not used'
        }, {
            id: 1,
            name: 'Active'
        }];

        vm.materialTypes = _getMaterialTypes($http, function () {
            vm.material = _getMaterial($http, vm.id);
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

_getMaterialTypes = function (http, callbackFn) {
    var materialTypes = [];

    http.get('/api/materialtypes')
        .then(function (response) {
            //Success
            angular.copy(response.data, materialTypes);
            callbackFn();
        }, function (error) {
            //Failure
            vm.errorMessages = 'Failed to load material types: ' + error;
        })
        .finally(function () {
    });

    return materialTypes;
}


_getMaterial = function (http, materialId) {
    var material = {};

    http.get('/api/materials/' + materialId)
        .then(function (response) {
                //Success
                angular.copy(response.data, material);
                material.datePurchased = parseDate(material.datePurchased);
                material.dateCreated = parseDate(material.dateCreated);
        }, function (error) {
                //Failure
                vm.errorMessage = 'Failed to load material with id ' + vm.id + ' : ' + error;
        })
        .finally(function () {
                vm.isBusy = false;
        });

    return material;
}