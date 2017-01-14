(function () {
    angular.module('app-materials', ['simpleControls', 'ngRoute', 'smart-table'])
        .config(['$locationProvider', '$routeProvider',
            function ($locationProvider, $routeProvider) {
                $locationProvider.hashPrefix('!');
                $locationProvider.html5Mode(true);
                $routeProvider.
                when('/', {
                    controller: 'MaterialsController',
                    controllerAs: 'vm',
                    templateUrl: '/views/material/materialsView.html'
                }).

                when('/editor/:materialId', {
                    controller: 'MaterialsEditorController',
                    controllerAs: 'vm',
                    templateUrl: '/views/material/materialsEditorView.html'
                }).

                otherwise({
                    redirectTo: '/'
                });
            }
      ])
})();