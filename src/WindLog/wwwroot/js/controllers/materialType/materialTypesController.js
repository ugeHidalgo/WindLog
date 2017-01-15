(function () {
    'use strict';

    angular
        .module('app-materialTypes')
        .controller('materialTypesController', materialTypesController);

    function materialTypesController($http) {
        var vm = this;
        vm.materialTypes = [];
        vm.materialTypeInForm = {};
        vm.errorMessage = '';
        vm.isBusy = true;
        vm.itemsByPage = 8;

        $http.get('/api/materialtypes')
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.materialTypes);
            }, function (error) {
                //Failure
                vm.errorMessage = 'Failed to load material types: ' + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });        

        vm.addItem = function () {
            vm.isBusy = true;
            vm.errorMessages = '';

            $http.post('/api/materialtypes', vm.materialTypeInForm)
                    .then(function (response) { //Success
                        //vm.materialTypes.push(response.data);
                        vm.materialTypes = _getMaterialTypes($http);
                        vm.materialTypeInForm = {};
                    }, function (error) { //Failure
                        vm.errorMessage = 'Failed to save new material type :' + error;
                    })
                    .finally(function () {
                        vm.isBusy = false;
                    });
        };

        vm.selectItem = function (row) {
            var year, month, day;

            vm.materialTypeInForm = _copyRow(row);
            vm.materialTypeInForm.dateCreated = parseDate(vm.materialTypeInForm.dateCreated);            
        };

        vm.newItem = function () {
            vm.materialTypeInForm = {};
            vm.materialTypeInForm.id = 0;
            vm.materialTypeInForm.dateCreated = new Date();
        };

        vm.clearSelectedItem = function () {
            vm.materialTypeInForm = {};
        };

        vm.removeItem = function (row) {
            vm.isBusy = true;
            $http.delete('/api/materialtypes/' + row.id)
                .then(function (response) { //success                    
                    vm.materialTypes = _removeItemFromArray(vm.materialTypes, row.id);
                }, function () { //Failure
                    vm.errorMessage = 'Failed to delete material type with id ' + row.id + ':' + error;
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };
    }
})();

_getMaterialTypes = function (http) {
    var materialTypes = [];

    http.get('/api/materialtypes')
    .then(function (response) {
        //Success
        angular.copy(response.data, materialTypes);
    }, function (error) {
        //Failure
        vm.errorMessages = 'Failed to load material types: ' + error;
    })
    .finally(function () {        
    });
    return materialTypes;
}

_copyRow = function (row) {
    var newRow = {};
    for (var propertyName in row) {
        newRow[propertyName] = row[propertyName];
    }
    return newRow;
}

_removeItemFromArray = function (items, itemId) {
    var newItems = [];
    items.forEach(function (item) {
        if (item.id !== itemId) {
            newItems.push(item);
        }
    });
    return newItems;
}