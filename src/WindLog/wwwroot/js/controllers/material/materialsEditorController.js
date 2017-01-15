(function () {
    'use strict';

    angular.module('app-materials')
    .controller('MaterialsEditorController', materialsEditorController);

    function materialsEditorController($routeParams,$http) {
        var vm = this, url;

        vm.id = $routeParams.materialId;
        vm.errorMessage = '';
        vm.isBusy = true;        
        vm.material = {
            id: vm.id,
            name: 'Rocket95',
            brand: 'Tabou',
            model: 'Rocket 95',
            year: '2010',
            datePurchased: new Date(2016, 4, 2),
            dateCreated: new Date(),
            memo: 'Comprada a SpinOut Tarifa.',
            materialType: {
                id: '9',
                name: 'Board'
            }
        };

        vm.newItem = function () {
            vm.material = {};
            vm.material.id = 0;
            vm.material.dateCreated = new Date();
            vm.material.datePurchased = new Date();
        };

        vm.clearSelectedItem = function () {
            vm.material = {};
        };
    }
})();