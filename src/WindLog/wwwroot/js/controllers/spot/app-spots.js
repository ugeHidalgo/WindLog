(function () {
    angular
        .module('app-spots', [
            'simpleControls',
            'ngRoute',
            'smart-table',
            'ui-notification'
        ])
        .config(['$locationProvider', '$routeProvider', 'NotificationProvider',
            function ($locationProvider, $routeProvider, NotificationProvider) {

                $locationProvider.hashPrefix('!');
                $locationProvider.html5Mode(true);

                $routeProvider.
                    when('/', {
                        controller: 'spotsController',
                        controllerAs: 'vm',
                        templateUrl: '/views/spot/spotsView.html'
                    }).

                    when('/editor/:spotId', {
                        controller: 'SpotsEditorController',
                        controllerAs: 'vm',
                        templateUrl: '/views/spot/spotsEditorView.html'
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
        ]);
})();