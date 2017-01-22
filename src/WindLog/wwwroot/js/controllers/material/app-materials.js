(function () {
    angular.
        module('app-materials', [
            'simpleControls',
            'ngRoute',
            'smart-table',
            'ui-notification'
        ]).
        config(['$locationProvider', '$routeProvider', 'NotificationProvider',
            function ($locationProvider, $routeProvider, NotificationProvider) {
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

                NotificationProvider.setOptions({
                    delay: 3000,
                    startTop: 20,
                    startRight: 10,
                    verticalSpacing: 20,
                    horizontalSpacing: 20,
                    positionX: 'center',
                    positionY: 'top'
                });
            }
        ])
})();