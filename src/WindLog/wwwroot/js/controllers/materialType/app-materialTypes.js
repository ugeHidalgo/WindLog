(function () {
    angular.
        module('app-materialTypes', [
            'simpleControls', //Busy indicator
            'ngRoute',
            'smart-table', //Grids
            'lrDragNDrop',  //Drag and drop columns on grids.
            'ui-notification'
        ]).
        config(['$locationProvider', '$routeProvider', 'NotificationProvider',
            function ($locationProvider, $routeProvider, NotificationProvider) {

                $locationProvider.hashPrefix('!');
                $locationProvider.html5Mode(true);
                $routeProvider.
                    when('/', {
                        controller: 'materialTypesController',
                        controllerAs: 'vm',
                        templateUrl: '/views/materialType/materialTypesView.html'
                    }).

                    when('/editor/:materialTypeId', {
                        controller: 'MaterialTypesEditorController',
                        controllerAs: 'vm',
                        templateUrl: '/views/materialType/materialTypesEditorView.html'
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