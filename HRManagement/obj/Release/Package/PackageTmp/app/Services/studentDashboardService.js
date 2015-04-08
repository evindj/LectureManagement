var studentDashboardService = [
    "$http", "$q", function ($http, $q) {

        var _lectures = [];
        var _videos=[];
        var _getLectures = function() {
            var deferred = $q.defer();
            
            $http.get("/api/v1/Category/getLect").then(function (result) {
                //success feed categories
                angular.copy(result.data, _lectures);
                
                deferred.resolve();
            },
                function() {
                    //error
                    deferred.reject();
                });
            return deferred.promise;
        };

        var _getVideos = function (idlecture) {

            var deferred = $q.defer();

            $http.get("/api/v1/Category/getVideos/"+idlecture).then(function (result) {
                //success feed categories
                angular.copy(result.data, _videos);

                deferred.resolve();
            },
                function () {
                    //error
                    deferred.reject();
                });
            return deferred.promise;

        };

        return{
            getLectures: _getLectures,
            lectures: _lectures,
            getVideos: _getVideos,
            videos:_videos
        }

    }
];

angularModule.factory('studentDashboardService', studentDashboardService);