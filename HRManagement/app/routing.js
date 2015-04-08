var configuration = ["$routeProvider", function ($routeProvider) {
   

    $routeProvider.when("/upload", {
        controller: "lectureController",
        templateUrl: "app/Lecturer/lUploadTemplate.html"
    });

    $routeProvider.when("/", {
        controller: "lectureController",
        templateUrl: "/template/indexTemplate.html"
    });

    

   
    $routeProvider.otherwise({ redirectTo: "/" });
}];
angularModule.config(configuration);