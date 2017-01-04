﻿(function () {
    angular.module('app-sessions', ['simpleControls', 'ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider.when('/', {
            controller: 'sessionsController',
            controllerAs: 'vm',
            templateUrl: '/views/sessionsView.html'
        });

        $routeProvider.otherwise({
            redirectTo: '/'
        });
    });
})();