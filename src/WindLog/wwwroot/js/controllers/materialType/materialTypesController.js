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
                        vm.materialTypes = _getMaterialTypes($http);
                        vm.materialTypeInForm = {};
                    }, function (error) { //Failure
                        vm.errorMessage = 'Failed to save new material type :' + error;
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