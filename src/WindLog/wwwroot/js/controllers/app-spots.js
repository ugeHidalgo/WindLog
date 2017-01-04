(function () {
    angular.module('app-spots', ['simpleControls', 'ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider.when('/', {
            controller: 'spotsController',
            controllerAs: 'vm',
            templateUrl: '/views/spotsView.html'
        });

        $routeProvider.otherwise({
            redirectTo: '/'
        });
    });
})();