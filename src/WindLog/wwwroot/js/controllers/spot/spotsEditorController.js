(function () {
    'use strict';

    angular.module('app-spots')
    .controller('SpotsEditorController', spotsEditorController);

    function spotsEditorController($routeParams, $http, Notification) {
        var vm = this, url,
            year, month, day;

        vm.id = $routeParams.spotId;
        vm.errorMessage = '';
        vm.isBusy = true;
        vm.spot = {};

        if (vm.id == '0') {
            vm.spot = _newSpot();
        }
        else {
            $http.get('/api/spots/' + vm.id)
            .then(function (response) {
                //Success
                angular.copy(response.data, vm.spot);
                vm.spot.dateCreated = parseDate(vm.spot.dateCreated);
            }, function (error) {
                //Failure
                vm.errorMessage = 'Failed to load spot (' + vm.id + '): ' + error;
                Notification.error('Failed to load selected spot !');
            })
            .finally(function () {
                vm.isBusy = false;
            });
        }

        vm.addItem = function () {
            vm.isBusy = true;
            vm.errorMessages = '';

            $http.post('/api/spots', vm.spot)
                    .then(function (response) { //Success                                                
                        vm.spot = {};
                        Notification.success('Spot successfully saved !');
                    }, function (error) { //Failure
                        vm.errorMessage = 'Failed to save spot :' + error;
                        Notification.error('Failed to save spot !');
                    })
                    .finally(function () {
                        vm.isBusy = false;
                    });
        };

        vm.newItem = function () {
            vm.spot = _newSpot();
        };

        vm.clearSelectedItem = function () {
            vm.spot = {};
        };

        vm.removeItem = function (row) {
            vm.isBusy = true;
            $http.delete('/api/spots/' + row.id)
                .then(function (response) { //success                                        
                }, function () { //Failure
                    vm.errorMessage = 'Failed to delete spot with id ' + row.id + ':' + error;
                    Notification.error('Failed to delete selected spot !');
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        };
    }
})();

_newSpot = function () {
    var spot = {};

    spot = {};
    spot.id = 0;
    spot.active = true;
    spot.dateCreated = new Date();

    return spot
}