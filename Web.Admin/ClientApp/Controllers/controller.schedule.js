﻿(function () {
    "use strict";

    var scheduleController = function ($scope, $http, $filter, dataService) {
        $scope.model = {};
        $scope.schedule = {};

        $scope.loadLaneDraw = loadLaneDraw;
        $scope.loadSchedule = loadSchedule;

        $scope.HasGames = getHasGames;
        $scope.Opponent = getOpponent;
        $scope.IsHomeTeam = getIsHomeTeam;
        $scope.Lane = getLane;

        loadLaneDraw('Tournament Men Single');
        loadSchedule();
        
        function loadLaneDraw(division) {
            $scope.model.Division = division;

            dataService.LoadLaneDraw(division).then(function (data) {
                $scope.model = data.data;
                $scope.model.Games.sort(function (a, b) {                    
                    return a.Number - b.Number;
                });
                var lastLocation = '';
                angular.forEach($scope.model.Games, function (value) {
                    value.ShowLocation = (value.CentreName != lastLocation);
                    lastLocation = value.CentreName;
                });
            });
        };

        function getMatch(province, game) {
            var match = $.grep($scope.model.Games, function (o) {
                return o.Number == game && (o.Home == province || o.Away == province);
            });
            return match.length ? match[0] : {};
        };

        function getHasGames(province) {
            return $.grep($scope.model.Games, function (o) {
                return o.Home == province || o.Away == province;
            }).length;
        };

        function getOpponent(province, game) {
            var match = getMatch(province, game);
            return match.Home == province ? match.Away : match.Home;
        };

        function getIsHomeTeam(province, game) {
            var match = getMatch(province, game);
            return match.Home == province;
        };

        function getLane(province, game) {
            var match = getMatch(province, game);
            return match.Home == province
                ? match.Lane + 1 
                : match.Lane;
        };

        function loadSchedule() {
            var data = dataService.LoadSchedule().then(function (data) {
                $scope.schedule = {
                    days: [],
                    events: []
                };

                angular.forEach(data.data.items, function (x) {
                    var key = x.start.dateTime
                        ? $filter('date')(new Date(x.start.dateTime), "yyyy-MM-dd")
                        : x.start.date;

                    if ($scope.schedule.days.indexOf(key) < 0) {
                        $scope.schedule.days.push(key);
                    }

                    var newEvent = {
                        key: key,
                        start: x.start.dateTime,
                        end: x.end.dateTime,
                        summary: x.summary,
                        description: x.description,
                        location: x.location
                    };

                    $scope.schedule.events.push(newEvent);
                });

                $scope.schedule.days = $filter('orderBy')($scope.schedule.days, '', false);
                $scope.currentDate = $filter('date')(new Date(), "yyyy-MM-dd");
            });
        }
    };

    app.controller("ScheduleController", ["$scope", "$http", "$filter", "dataService", scheduleController]);
}());