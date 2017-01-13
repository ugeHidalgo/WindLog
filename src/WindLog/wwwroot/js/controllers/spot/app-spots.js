(function () {
    angular
        .module('app-spots', [
            'simpleControls',
            'ngRoute',
            'smart-table'])
        .config(function ($routeProvider) {
            $routeProvider.when('/', {
                controller: 'spotsController',
                controllerAs: 'vm',
                templateUrl: '/views/spot/spotsView.html'
            });

            $routeProvider.otherwise({
                redirectTo: '/'
            });
        });
})();