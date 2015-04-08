

var lectureService = ["$http","$q", function ($http, $q) {
    var _categories = [];
        var _serviceUploaded = false;
    var _isInit = false;
    var _isCategoryReady = function() {
        return _isInit;
    }

        var _getCategories = function() {
            var deferred = $q.defer();
            
            $http.get("/api/v1/Category/get").then(function (result) {
                //success feed categories
                angular.copy(result.data, _categories);
                    _isInit = true;
                    deferred.resolve();
                },
                function() {
                    //error
                    deferred.reject();
                });
            return deferred.promise;
        };



        var _uploadLecture = function (files) {
            var deferred = $q.defer();

            $http.post("/api/v1/Category").then(function (result) {
                //success feed categories
                angular.copy(result.data, _categories);
                    _serviceUploaded = true;
                deferred.resolve();
            },
                function () {
                    //error
                    deferred.reject();
                });
            return deferred.promise;
        };

        return {
            getCategories: _getCategories,
            categories: _categories,
            isCategoryReady: _isCategoryReady,
            serviceUploaded: _serviceUploaded,
            uploadLecture:_uploadLecture
        }

    }
];

angularModule.factory("lectureService", lectureService);