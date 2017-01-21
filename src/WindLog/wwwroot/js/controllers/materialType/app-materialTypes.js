(function () {
    angular.
        module('app-materialTypes', [
            'simpleControls', //Busy indicator
            'ngRoute',
            'smart-table', //Grids
            'lrDragNDrop'  //Drag and drop columns on grids.
        ]).
        config(['$locationProvider', '$routeProvider',
            function ($locationProvider, $routeProvider) {

                $locationProvider.hashPrefix('!');
                $locationProvider.html5Mode(true);
                $routeProvider.
                    when('/', {
                        controller: 'materialTypesController',
                        controllerAs: 'vm',
                        templateUrl: '/views/materialType/materialTypesView.html'
                    }).

                    when('/editor/:materialTypeId', {
                        controller: 'MaterialTypesEditorController',
                        controllerAs: 'vm',
                        templateUrl: '/views/materialType/materialTypesEditorView.html'
                    }).

                    otherwise({
                        redirectTo: '/'
                    });
            }
        ]);
})();