﻿(function () {
    'use strict';

    angular
        .module('app-materials')
        .controller('MaterialsController', materialsController);

    function materialsController($http, Notification) {
        var vm = this;

        vm.materials = [];
        vm.errorMessage = '';
        vm.isBusy = true;
        vm.itemsByPage = 10;

        $http.get('/api/materials')
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.materials);                
            }, function (error) {
                //Failure
                vm.errorMessage = 'Failed to load materials: ' + error;
                Notification.error('Failed to load material !');
            })
            .finally(function () {
                vm.isBusy = false;
            });
    }
})();