
'use strict';

statTrackerApp.controller('roundController',
    function ($scope, $http, $window, $route) {
        $scope.newRound = {};
        $scope.savedRound = {};
        $scope.roundDetails = [];
        $scope.rounds = [];

        $scope.facilities = {};
        $scope.courses = {};
        $scope.tees = {};
        $scope.holes = {};

        //get rounds on load
        $http.get("/api/round/")
                .then(function (result) {
                    // Successful
                    angular.copy(result.data, $scope.rounds);

                    //$scope.roundDetails = result.data;
                },
                    function () {
                        // Error
                        alert("Could not load rounds.");
                    });

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
        $scope.getCourses = function (facilityId) {
            $http.get("/api/facilities/" + facilityId + "/courses")
                .then(function (result) {
                    // Successful
                    $scope.courses = result.data;
                    //angular.copy(result.data, $scope.courses);
                },
                    function () {
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

        //get holes
        $scope.getHoles = function (teeId) {
            $http.get("/api/hole/" + teeId)
                .then(function (result) {
                    // Successful
                    $scope.holes = result.data;
                },
                    function () {
                        // Error
                        //deferred.reject();
                        alert("Could not load holes.");
                    });
        };

        $scope.addRound = function () {
            $http.post("/api/round/", $scope.newRound)
                .then(function (result) {
                    // Successful
                    //angular.copy(result.data, $scope.facilities);
                    //$window.location = "#/facilities";
                    $scope.savedRound = result.data;
                    $scope.getRoundDetails();
                    $window.location.href = '#/roundDetail';
                },
          function () {
              // Error
              alert("Could not save new round");
          });
        };

        $scope.deleteRound = function (round) {
            if (confirm("Are you sure you want to delete this round \n\n '" + round.roundId + "'")) {
                $http.delete('/api/round/' + round.roundId).then(function () {
                    // Successful
                    //angular.copy(result.data, $scope.facilities);
                    $route.reload();
                },
                    function () {
                        // Error
                        alert("Could not delete round.");
                    });
            }
        };

        $scope.getRoundDetails = function () {
            $http.get("/api/roundDetail/" + $scope.savedRound.roundId)
                .then(function (result) {
                    // Successful
                    angular.copy(result.data, $scope.roundDetails);

                    //$scope.roundDetails = result.data;
                },
                    function () {
                        // Error
                        alert("Could not load round details.");
                    });
        };

        $scope.getRoundDetailsById = function (roundId) {
            $http.get("/api/roundDetail/" + roundId)
                .then(function (result) {
                    // Successful
                    angular.copy(result.data, $scope.roundDetails);

                    //$scope.roundDetails = result.data;
                },
                    function () {
                        // Error
                        alert("Could not load round details.");
                    });
        };

    });