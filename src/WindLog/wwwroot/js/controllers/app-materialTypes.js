(function () {
    angular
        .module('app-materialTypes', [
            'simpleControls',
            'ngRoute',
            'smart-table'])
        .config(function ($routeProvider) {
            $routeProvider.when('/', {
                controller: 'materialTypesController',
                controllerAs: 'vm',
                templateUrl: '/views/materialTypesView.html'
            });

            $routeProvider.otherwise({
                redirectTo: '/'
            });
        });
})();