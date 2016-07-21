// Defining angularjs module
var app = angular.module('demoModule', ['ui.bootstrap', 'ngResource']);

// Defining angularjs Controller and injecting personService
app.controller('demoCtrl', function ($scope, $http, personService) {

    $scope.personData = null;
    

    personService.GetAllRecords().then(function (d) {
       
        $scope.personData = d.data; // Success
        document.getElementById('diverror').style.display = "block";


    }, function () {
        alert('Error Occured !!!'); // Failed
    });

    $scope.totalItems = $scope.personData.length;
    $scope.numPerPage = 5;
    $scope.paginate = function (value) {
        var begin, end, index;
        begin = ($scope.currentPage - 1) * $scope.numPerPage;
        end = begin + $scope.numPerPage;
        index = $scope.students.indexOf(value);
        return (begin <= index && index < end);
    };




    $scope.person = {
        Id: '',
        UserName: '',
 
        FirstName: '',
      
        LastName: '',
      
        Email: '',
     

        MessageError: '',
        MessageSuccess: '',
        Error: false,
        Success: false,

    };


    // Delete product details
    $scope.delete = function (index) {
     
        $http({
            method: 'DELETE',
            url: '/XpanelAdmin/Delete/' + $scope.personData[index].id,
        }).then(function successCallback(response) {
            $scope.personData.splice(index, 1);
            alert("Product Deleted Successfully !!!");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };

});

///



//////










// Here I have created a factory which is a populer way to create and configure services. You may also create the factories in another script file which is best practice.
// You can also write above codes for POST,PUT,DELETE in this factory instead of controller, so that our controller will look clean and exhibits proper Separation of Concern.
app.factory('personService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get('/XpanelAdmin/GetAll');
    }
    return fac;
});