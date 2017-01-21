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

        if (vm.id === '0')
        {
            _prepareForNewItem(vm);
            vm.materialTypes = _getMaterialTypes($http, vm );
        }
        else {
            vm.materialTypes = _getMaterialTypes($http, vm, function () {
                vm.material = _getMaterial($http, vm);
            });
        }        

        vm.addItem = function () {
            vm.isBusy = true;
            vm.errorMessages = '';

            $http.post('/api/materials', vm.material)
                    .then(function (response) { //Success                                            
                        vm.material = {};
                    }, function (error) { //Failure
                        vm.errorMessage = 'Failed to save new material :' + error;
                    })
                    .finally(function () {
                        vm.isBusy = false;
                    });
        };

        vm.newItem = function () {
            vm.material = {};
            vm.id = 0;
            vm.material.id = 0;
            vm.material.dateCreated = new Date();
            vm.material.datePurchased = new Date();
            vm.material.secondHand = false;
            vm.material.state = true;
        }

        vm.clearSelectedItem = function () {
            vm.material = {};
        };
    }
})();

_getMaterialTypes = function (http, vm, callbackFn) {
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


_getMaterial = function (http, vm ) {
    var material = {};
    
    http.get('/api/materials/' + vm.id)
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

_prepareForNewItem = function (vm) {
    vm.material = {};
    vm.id = 0;
    vm.material.id = 0;
    vm.material.dateCreated = new Date();
    vm.material.datePurchased = new Date();
    vm.material.secondHand = false;
    vm.material.state = true;
}