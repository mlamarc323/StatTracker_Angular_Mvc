'use strict';

statTrackerApp.controller('roundController',
    function($scope, $http, $window, $route) {
        $scope.newRound = {};
        $scope.roundDetails = {};

        $scope.facilities = {};
        $scope.courses = {};
        $scope.tees = {};

        //get facilities
        $http.get("/api/facilities")
          .then(function (result) {
              // Successful
              //angular.copy(result.data, $scope.facilities);
                $scope.facilities = result.data;
            },
          function () {
              // Error
              //deferred.reject();
              alert("could not load facilities");
          });

        //get courses
        $scope.getCourses = function(facilityId) {
            $http.get("/api/facilities/" + facilityId + "/courses")
                .then(function(result) {
                    // Successful
                    $scope.courses = result.data;
                        //angular.copy(result.data, $scope.courses);
                    },
                    function() {
                        // Error
                        //deferred.reject();
                        alert("Could not load Courses.");
                    });
        };

        //get tees
        $scope.getTees = function (courseId) {
            $http.get("/api/course/" + courseId + "/tees")
                .then(function (result) {
                    // Successful
                    //angular.copy(result.data, $scope.tees);
                    $scope.tees = result.data;
                },
                    function () {
                        // Error
                        //deferred.reject();
                        alert("Could not load tees.");
                    });
        };

        $scope.addRound = function () {
            $http.post("/api/round/", $scope.newRound)
                .then(function () {
                    // Successful
                    //angular.copy(result.data, $scope.facilities);
                    //$window.location = "#/facilities";
                },
          function () {
              // Error
              alert("Could not save new round");
          });
        };
    });