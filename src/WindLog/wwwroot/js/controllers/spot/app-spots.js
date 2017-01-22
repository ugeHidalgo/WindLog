(function () {
    angular
        .module('app-spots', [
            'simpleControls',
            'ngRoute',
            'smart-table',
            'ui-notification'
        ])
        .config(['$routeProvider', 'NotificationProvider',
            function ($routeProvider, NotificationProvider) {
                $routeProvider.
                    when('/', {
                        controller: 'spotsController',
                        controllerAs: 'vm',
                        templateUrl: '/views/spot/spotsView.html'
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