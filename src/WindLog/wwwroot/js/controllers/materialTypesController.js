(function () {
    'use strict';

    angular
        .module('app-materialTypes')
        .controller('materialTypesController', materialTypesController);

    function materialTypesController() {
        var vm = this;
        vm.materialTypes = [{
            created: new Date(),
            name: "Titan",
            brand: "Naish",
            model: "Titan 110"
        }, {
            created: new Date(),
            name: "Rocket",
            brand: "Tabou",
            model: "Rocket 95"
        }, {
            created: new Date(),
            name: "RRD Wave",
            brand: "RRD",
            model: "Wave Cult 82 LTD"
        }];
    }
})();