var studentDashboardController = [
    "$scope", "$http", "studentDashboardService", function ($scope, $http, studentDashboardService) {

        studentDashboardService.getLectures().then(function() {
            
        } , function() {
            
        });
        var lectures = studentDashboardService.lectures;
       
     
        $scope.firstRow = studentDashboardService.lectures;
        $scope.isHome = true;
        $scope.isLecture = false;
        var base = "/Uploads/Tmp/FileUploads/";
        $scope.source = "";

        $scope.videoClick = function videoClick(index, indexParent) {
            $scope.source = base+$scope.modules[indexParent].Videos[index].Path;
            //$scope.source = "/FLAWLESS.mp4";
            // alert("video index"+ $scope.modules[indexParent].Videos[index].Title);
            var myVideo = document.getElementById("videoPlayer");
            myVideo.load();
        
        }
        $scope.openLecture = function openLecture(index) {
            var lecture = $scope.firstRow[index];
            $scope.isHome = false;
            studentDashboardService.getVideos(lecture.IdLecture).then(
                function () {
                    //success
                    $scope.modules = studentDashboardService.videos;
                    $scope.isHome = false;
                    $scope.isLecture = true;

                }, function () {
                    //failure
                
            });
            return 4;
        };


    }
];

angularModule.controller('studentDashboardController', studentDashboardController);


