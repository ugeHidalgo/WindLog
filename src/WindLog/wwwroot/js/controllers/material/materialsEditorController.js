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
            name: 'Una tabla'
        };        
    }
})();