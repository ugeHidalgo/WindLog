(function () {
    'use strict';

    angular
        .module('app-materialTypes')
        .controller('materialTypesController', materialTypesController);

    function materialTypesController($http, Notification) {
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
                Notification.error('Failed to load material types !');
            })
            .finally(function () {
                vm.isBusy = false;
            });                    
    }
})();

//_getMaterialTypes = function (http) {
//    var materialTypes = [];

//    http.get('/api/materialtypes')
//    .then(function (response) {
//        //Success
//        angular.copy(response.data, materialTypes);
//    }, function (error) {
//        //Failure
//        vm.errorMessages = 'Failed to load material types: ' + error;
//    })
//    .finally(function () {        
//    });
//    return materialTypes;
//}