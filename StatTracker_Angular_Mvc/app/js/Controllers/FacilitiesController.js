'use strict';

statTrackerApp.controller('FacilitiesController',
    function FacilitiesController($scope, $http, $window, $route) {
        $scope.sortorder = 'name';
        $scope.isBusy = false;
        $scope.myStyle = { color: 'red' };
        $scope.snippet = '<span style="color:red">hi there</span>';
        $scope.boolValue = true;
        $scope.myclass = "blue";
        $scope.buttonDisabled = true;
        $scope.facilities = [];
        $scope.newFacility = {};

        $http.get("/api/facilities?includeEverything=true")
          .then(function (result) {
              // Successful
              angular.copy(result.data, $scope.facilities);
          },
          function () {
              // Error
              //deferred.reject();
              alert("could not load facilities");
          });

        $scope.addFacility = function() {
            $http.post("/api/facilities/", $scope.newFacility)
                .then(function () {
              // Successful
              //angular.copy(result.data, $scope.facilities);
              $window.location = "#/facilities";
          },
          function () {
              // Error
              alert("could not save new facility");
          });
        };

        $scope.deleteFacility = function (facility) {
            if (confirm("Are you sure you want to delete \n\n '" + facility.name + "'")) {
                $http.delete('/api/facilities/' + facility.facilityId).then(function() {
                        // Successful
                        //angular.copy(result.data, $scope.facilities);
                        $route.reload();
                    },
                    function() {
                        // Error
                        alert("could not delete facility");
                    });
            }
        };
        
    }
);
