(function () {

    'use strict';

    var app = angular.module('journey-planner', []);

    app.controller('MainController', ['$scope', 'dataService', function ($scope, dataService) {

        $scope.errMsg = '';

        function init() {
            dataService.getAllStations().then(function (data) {
                var stations = data.data;
                $scope.stations = stations.map(function (e) { return e.toLowerCase(); });
                //console.log($scope.stations);
            });
        }

        $scope.getJourney = function () {

            $scope.errMsg = '';
            $scope.results = [];
            if (!verifyStations()) {
                return;
            }
           
            dataService.getJourney($scope.fromStation, $scope.toStation, $scope.viaStation, $scope.excludingStation).then(function (data) {
                var journey = data.data;
                $scope.results = journey.RouteResult;
            }, function (err) {
                $scope.errMsg = "An error has occurred. " + err.statusText + " : " + err.data;
            });
        };

        $scope.setStation = function(station, keyModel) {
            $scope[keyModel] = station;
        };

        $scope.displayStations = function (modelStation) {

            // hide auto complete if no value present yet
            if (!modelStation) {
                return false; 
            }

            // show auto complete if value present but not in the stations array
            if ($scope.stations.indexOf(modelStation.toLowerCase()) === -1) {
                return true;
            }

            return false;
        };


        function verifyStations() {

            /*$scope.fromStationErr = '';
            $scope.toStationErr = '';
            $scope.viaStationErr = '';
            $scope.excludingStationErr = '';
            var numErrors = 0;

            var from = $scope.fromStation;
            var to = $scope.toStation;
            if ($scope.stations.indexOf(from) === -1) {
                $scope.fromStationErr = "From station not found";
                numErrors++;
            }
            if ($scope.stations.indexOf(to) === -1) {
                $scope.toStationErr = "To station not found";
                numErrors++;
            }

            if (angular.isDefined($scope.viaStation)) {
                if ($scope.viaStation.length > 0) {
                    if ($scope.stations.indexOf($scope.viaStation) === -1) {
                        $scope.viaStationErr = "Via station not found";
                        numErrors++;
                    }
                }
            }

            if (angular.isDefined($scope.excludingStation)) {
                if ($scope.excludingStation.length > 0) {
                    if ($scope.stations.indexOf($scope.excludingStation) === -1) {
                        $scope.excludingStationErr = "Excuding station not found";
                        numErrors++;
                    }
                }
            }

            return numErrors === 0;*/
            return true;
        }

        init();
    }]);


    app.factory('dataService', ['$http', function ($http) {

        var service = {
            getAllStations: getAllStations,
            getJourney: getJourney
        };

        return service;

        function getAllStations() {
            return $http.get('/api/journeyplanner/stations');
        }

        function getJourney(fromStation, toStation, viaStation, excludingStation) {
            viaStation = viaStation || '';
            excludingStation = excludingStation || '';
            return $http.get('/api/journeyplanner?startStation=' + fromStation + '&finishStation=' + toStation + '&viaStation=' + viaStation
                + '&excludingStation=' + excludingStation);
        }

    }
    ]);

})();