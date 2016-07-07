// Defining angularjs module
var app = angular.module('SettingModule', ['ngSanitize']);

// Defining angularjs Controller and injecting personService
app.controller('SettingCtrl', function ($scope, $http, personService) {

   

    $scope.person = {
        Id: '',
        PasswordHash: '',
        NewPassword:'',
        MessageError: '',
        MessageSuccess: '',
        Error: false,
        Success: false,

    };


 
    // Reset person details
    $scope.clear = function () {
        $scope.person.Id = '';
        $scope.person.PasswordHash = '';
       
        $scope.person.PasswordOld = '';
    }

    
    
    //Update  Password
    $scope.UpdatePassword = function () {


        $scope.person.Error = false;
        if (CheckValidation()) {

            $http({
                method: 'POST',
                url: '/Account/UpdatePassword/',
                data: $scope.person
            }).then(function successCallback(response) {
                if (response.data == "") {
                    $scope.person.MessageError = "<br/> - Current Password is incorrect.";
                    $scope.person.Error = true;
                    $scope.clear();
                    $('#ConfirmPassword').val("");
          
                    return;
                }
                else
                {
                    $scope.clear();
                    $('#ConfirmPassword').val("");
                    window.location.href = "../Account/WelcomeBack";

                }
               
            }, function errorCallback(response) {

            });
        }
        else {

            $scope.person.MessageError = $scope.person.MessageError + "<br> -Please fix validations.";
            $scope.person.Error = true;

        }

    };




    function CheckValidation() {

        var IsError = true;
        $scope.person.MessageError = '';
            if ($scope.person.PasswordHash == "") {
                $('#PasswordHash').addClass('ng-dirty');
                $('#PasswordHash').addClass('ng-invalid');
                IsError = false;

            }
            else {
                if ($('#NewPassword').val() != $('#ConfirmPassword').val()) {
                    $('#NewPassword').addClass('ng-dirty');
                    $('#NewPassword').addClass('ng-invalid');
                    $('#ConfirmPassword').addClass('ng-dirty');
                    $('#ConfirmPassword').addClass('ng-invalid');
                    $scope.person.MessageError = $scope.person.MessageError + "<br> -Password and confirm password doesnot match.";
                    IsError = false;
                }
            }

            if ($('#ConfirmPassword').val() == "") {
                $('#ConfirmPassword').addClass('ng-dirty');
                $('#ConfirmPassword').addClass('ng-invalid');
                IsError = false;
            }
            return IsError;
        }

});

// Here I have created a factory which is a populer way to create and configure services. You may also create the factories in another script file which is best practice.
// You can also write above codes for POST,PUT,DELETE in this factory instead of controller, so that our controller will look clean and exhibits proper Separation of Concern.
app.factory('personService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
       // return $http.get('/Account/GetRecordById');
    }
    return fac;
});