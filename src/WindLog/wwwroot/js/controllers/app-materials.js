﻿(function () {
	angular.module('app-materials', ['simpleControls', 'ngRoute'])
    .config(function ($routeProvider) {
    	$routeProvider.when('/', {
    		controller: 'materialsController',
    		controllerAs: 'vm',
    		templateUrl: '/views/materialsView.html'
    	});

    	$routeProvider.otherwise({
    		redirectTo: '/'
    	});
    });
})();