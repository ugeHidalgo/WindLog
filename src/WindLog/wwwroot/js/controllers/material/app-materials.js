(function () {
    angular
        .module('app-materials', [
            'simpleControls',
            'ngRoute',
            'smart-table'])
        .config(function ($routeProvider) {
            $routeProvider.when('/', {
                controller: 'materialsController',
                controllerAs: 'vm',
                templateUrl: '/views/material/materialsView.html'
            });

            $routeProvider.otherwise({
                redirectTo: '/'
            });
        });
})();