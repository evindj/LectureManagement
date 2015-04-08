
/// <reference path="../../hrmanagement/scripts/angular.js" />
/// <reference path="../../hrmanagement/scripts/angular-route.js" />
/// <reference path="../scripts/jasmine.js" />
/// <reference path="../../hrmanagement/app/app.js" />
/// <reference path="../../hrmanagement/app/services/lectureservice.js" />
/// <reference path="../../hrmanagement/app/lecturer/lecturecontroller.js" />
/// <reference path="../../hrmanagement/scripts/angular-mocks.js" />
/// <reference path="../../hrmanagement/scripts/angular-ui/ui-bootstrap-tpls.min.js" />
/// <reference path="../../hrmanagement/scripts/angular-file-upload.js" />
/// <reference path="../../hrmanagement/app/controller/studentdashboardcontroller.js" />
/// <reference path="../../hrmanagement/app/services/studentdashboardservice.js" />

describe("lecture module tests-->", function() {
    beforeEach(function() {
        module("angularModule");
    });
   // var $httpBackend;

   


    describe("lectureService-->", function () {

        beforeEach(inject(function ($controller, $rootScope, $http, lectureService, $upload,$httpBackend) {
            this.$httpBackend = $httpBackend;
            this.scope = $rootScope.$new();
            $controller('lectureController', {
                $scope: this.scope,
                $http: $http,
                $upload: $upload,
                lectureService: lectureService
            });
        }));

      

        it("lecture controller test category API called", function() {
            //invoke the service here and test

            expect(this.$httpBackend).toBeDefined();
            this.$httpBackend.expectPOST('/').respond(200);
            
            //$httpBackend.flush();

            expect(this.scope.dynamic).toEqual(10);
        });


        it("can load Categories", inject(function (lectureService) {
            //invoke the service here and test
            expect(lectureService.categories).toEqual([]);
            lectureService.getCategories().then(function() {
                //success
                    expect(lectureService.categories.length).toBeGreaterThan(0);
                }, 
            function() {
                //failure
            });
        }));

        it("uploads lecture --->", inject(function(lectureService) {
            expect(lectureService.serviceUploaded).toEqual(false);
            lectureService.uploadLecture().then(function() {
                //success
                expect(lectureService.serviceUploaded).toEqual(true);
            }, function() {

            });
        }));
    });

    describe("Student Dashboard module", function() {
        
        beforeEach(inject(function ($controller, $rootScope, $http, studentDashboardService, $httpBackend) {
            this.$httpBackend = $httpBackend;
            this.scope = $rootScope.$new();
            $controller('studentDashboardController', {
                $scope: this.scope,
                $http: $http,
                studentDashboardService: studentDashboardService
            });
        }));

        it(" creates controler studentDashBoard", function () {
            expect(this.scope.openLecture(1)).toEqual(4);

        });

        it(" gets videos from specfic lecture", inject(function (studentDashboardService) {
            expect(studentDashboardService.videos).toEqual([]);
            studentDashboardService.getVideos(5).then(function() {
                //success
                var videos = studentDashboardService.videos;
                expect(videos.length).toBeGreaterThan(0);
            },
            function() {
                //failure
            });
            

        }));

    } );
});

