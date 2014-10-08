'use strict';


// Declare app level module which depends on filters, and services
var statTrackerApp = angular.module('statTrackerApp', ['ngSanitize'])
    .config([
        '$routeProvider', function($routeProvider) {
    $routeProvider.when('/facilities', { templateUrl: '/app/partials/facilities.html' });//, controller: statTrackerApp.controller.FacilitiesController });
            $routeProvider.when('/newFacility', { templateUrl: '/app/partials/facility-add.html' });
            //  $routeProvider.when('/view2', {templateUrl: 'partials/partial2.html', controller: MyCtrl2});
            $routeProvider.otherwise({ redirectTo: '/facilities' });
            //$httpProvider.defaults.headers.delete = { 'Accept-Type': 'application/json','Content-Type': 'application/json' };

        }
    ]);