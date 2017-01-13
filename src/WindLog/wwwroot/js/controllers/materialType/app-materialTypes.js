(function () {
    angular
        .module('app-materialTypes', [
            'simpleControls', //Busy indicator
            'ngRoute',
            'smart-table', //Grids
            'lrDragNDrop'  //Drag and drop columns on grids.
        ])
        .config(function ($routeProvider) {
            $routeProvider.when('/', {
                controller: 'materialTypesController',
                controllerAs: 'vm',
                templateUrl: '/views/materialType/materialTypesView.html'
            });

            $routeProvider.otherwise({
                redirectTo: '/'
            });
        });
})();