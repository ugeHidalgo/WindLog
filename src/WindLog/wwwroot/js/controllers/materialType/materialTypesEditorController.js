(function () {
    'use strict';

    angular.module('app-materialTypes')
    .controller('MaterialTypesEditorController', materialTypesEditorController);

    function materialTypesEditorController($routeParams, $http, Notification) {
        var vm = this, url,
            year, month, day;

        vm.id = $routeParams.materialTypeId;
        vm.errorMessage = '';
        vm.isBusy = true;
        vm.materialType = {};

        if (vm.id=='0') {
            vm.materialType = {};
            vm.materialType.id = 0;
            vm.materialType.dateCreated = new Date();
        }
        else {
            $http.get('/api/materialtypes/' + vm.id)
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.materialType);
                vm.materialType.dateCreated = parseDate(vm.materialType.dateCreated);
            }, function (error) {
                //Failure
                vm.errorMessage = 'Failed to load material type (' + vm.id + '): ' + error;
                Notification.error('Failed to load selected material type !');
            })
            .finally(function () {
                vm.isBusy = false;
            });
        }

        vm.addItem = function () {
            vm.isBusy = true;
            vm.errorMessages = '';

            $http.post('/api/materialtypes', vm.materialType)
                    .then(function (response) { //Success                                                
                        vm.materialType = {};
                        Notification.success('Material type successfully saved !');
                    }, function (error) { //Failure
                        vm.errorMessage = 'Failed to save new material type :' + error;
                        Notification.error('Failed to save new material type !');
                    })
                    .finally(function () {
                        vm.isBusy = false;
                    });
        };

        vm.newItem = function () {
            vm.materialType = {};
            vm.materialType.id = 0;
            vm.materialType.dateCreated = new Date();
        };

        vm.clearSelectedItem = function () {
            vm.materialType = {};
        };

        vm.removeItem = function (row) {
            vm.isBusy = true;
            $http.delete('/api/materialtypes/' + row.id)
                .then(function (response) { //success                                        
                }, function () { //Failure
                    vm.errorMessage = 'Failed to delete material type with id ' + row.id + ':' + error;
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };
    }
})();