
var lectureController = ["$scope","$http","lectureService","$upload",
    function ($scope, $http, lectureService,$upload) {
        $scope.upload = [];
        $scope.categories = lectureService.categories;
        $scope.fileUploadObj = {idCategory:0};
        $scope.dynamic = 10;
        $scope.isUploading = false;
        $scope.onFileSelect = function ($files) {
            //$files: an array of files selected, each file has name, size, and type.
            $scope.fileUploadObj.idCategory = $scope.category.Id;
            for (var i = 0; i < $files.length; i++) {
                var $file = $files[i];
                (function (index) {
                    $scope.isUploading = true;
                    $scope.upload[index] = $upload.upload({
                        url: "/api/v1/category/post", // webapi url
                        method: "POST",
                        data: { fileUploadObj: $scope.fileUploadObj },
                        file: $file
                    }).progress(function (evt) {// get upload percentage
                        
                        $scope.dynamic = parseInt(100.0 * evt.loaded / evt.total);
                       
                        console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
                    }).success(function (data, status, headers, config) {
                        // file is uploaded successfully
                        $scope.isUploading = false;
                        console.log(data);
                    }).error(function (data, status, headers, config) {
                        // file failed to upload
                        $scope.isUploading = false;
                        console.log(data);
                    });
                })(i);
            }
        }

        $scope.abortUpload = function (index) {
            $scope.upload[index].abort();
        }

        $scope.submitForm = function() {
            var cat = $scope.category;
          //  alert(cat.Id);
        }

        $scope.isBusy = false;
        if (lectureService.isCategoryReady()==false) {
            $scope.isBusy = true;
            lectureService.getCategories().then(function() {

                },
                function() {
                    alert("could not load the data");
                }).then(function() {
                    $scope.isBusy = false;
            });
        };
    }];
angularModule.controller('lectureController', lectureController);