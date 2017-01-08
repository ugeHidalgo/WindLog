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
        vm.itemsByPage = 8;

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
            vm.isBusy = true;
            vm.errorMessage = '';

            $http.post('/api/materialtypes', vm.materialTypeInForm)
                .then(function (response) { //Success
                    vm.materialTypes.push(response.data);
                    vm.materialTypeInForm = {};
                }, function (error) { //Failure
                    vm.errorMessage = 'Failed to save new material type :' + error;
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };

        vm.selectRow = function (row) {
            var year, month, day;

            vm.materialTypeInForm = _copyRow(row);            
            year = row.dateCreated.slice(0, 4);
            month = row.dateCreated.slice(5, 7)-1;
            day = row.dateCreated.slice(8, 10);
            vm.materialTypeInForm.dateCreated = new Date(year,month,day);
        };

        vm.newItem = function () {
            vm.materialTypeInForm = {};
            vm.materialTypeInForm.id = -1;
            vm.materialTypeInForm.dateCreated = new Date();
        };

        vm.clearItem = function () {
            vm.materialTypeInForm = {};
        };

        vm.removeRow = function (row) {
            vm.isBusy = true;
            $http.delete('/api/materialtypes/' + row.id)
                .then(function (response) { //success                    
                    vm.materialTypes = _removeItemFromArray(vm.materialTypes, row.id);
                }, function () { //Failure
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };
    }
})();

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