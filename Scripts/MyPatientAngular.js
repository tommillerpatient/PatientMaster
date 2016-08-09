// Defining angularjs module
var app = angular.module('demoModule', ['ngSanitize']);

// Defining angularjs Controller and injecting personService
app.controller('demoCtrl', function ($scope, $http, personService) {

    $scope.personData = null;
    // Fetching records from the factory created at the bottom of the script file
    ///get all record

    personService.GetAllRecords().then(function (d) {
        $scope.personData = d.data; // Success

    }, function () {

    });


});

app.factory('personService', function ($http) {
    var fac = {};
    $('#diverror').hide();
    fac.GetAllRecords = function () {
        return $http.get('/Account/GetMyPatient');
    }
    return fac;
});