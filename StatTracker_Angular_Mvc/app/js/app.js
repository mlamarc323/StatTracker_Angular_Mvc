'use strict';


// Declare app level module which depends on filters, and services
var statTrackerApp = angular.module('statTrackerApp', ['ngSanitize'])
    .config([
        '$routeProvider', function($routeProvider) {
            $routeProvider.when('/facilities', { templateUrl: '/app/partials/facilities.html' });
            $routeProvider.when('/newFacility', { templateUrl: '/app/partials/facility-add.html' });
            $routeProvider.otherwise({ redirectTo: '/facilities' });
        }
    ]);