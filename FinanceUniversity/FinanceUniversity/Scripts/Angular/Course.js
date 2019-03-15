/// <reference path="Course.js" />

var MyApp = angular.module('MyApp', []);
MyApp.controller('MyController', function ($scope, RecordService) { //inject $scope and RecordServce.
    $scope.Contact = null;
    RecordService.GetRecord().then(function (d) {
        $scope.Contact = d.data; // Success
    }, function () {
        alert('Failed'); // Failed
    });
});

//The concept of the factory service is same as service layer in ASP.NET MVC Application.
MyApp.factory('RecordService', function ($http) {
    var fac = {};
    //GetRecord function will call the GetStudentRecord action method.
    fac.GetRecord = function () {
        return $http.get('/Course/GetAllCourseData');
    }
    return fac;
});