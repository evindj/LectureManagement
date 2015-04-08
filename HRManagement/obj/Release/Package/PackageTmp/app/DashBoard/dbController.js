angularModule.controller('dbController',
    function dbController($scope, dbService) {
        $scope.lecture = dbService.lecture;
    });