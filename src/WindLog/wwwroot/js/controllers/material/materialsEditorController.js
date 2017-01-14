(function () {
    'use strict';

    angular.module('app-materials')
    .controller('MaterialsEditorController', materialsEditorController);

    function materialsEditorController($routeParams,$http) {
        var vm = this, url;

        //vm.id = '27';        
        //vm.errorMessage = '';
        //vm.isBusy = true;        
        //vm.material = {
        //    id: '27',
        //    name: 'hola'
        //};        
    }
})();