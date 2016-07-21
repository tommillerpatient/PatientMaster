// Defining angularjs module
var app = angular.module('SettingModule', ['ngSanitize']);

// Defining angularjs Controller and injecting personService
app.controller('SettingChangeCtrl', function ($scope, $http, personService) {



    $scope.staff = {
        Id: '',
        Password: '',
        NewPassword: '',
        MessageError: '',
        MessageSuccess: '',
        Error: false,
        Success: false,

    };



    // Reset person details
    $scope.clear = function () 
    {
        $scope.staff.Id = '';
        $scope.staff.Password = '',
        $scope.staff.NewPassword= ''

    }



    //Update  Password
    $scope.UpdatePassword = function () {

        $scope.staff.MessageError = '';
        $scope.staff.Error = false;
        if (CheckValidationPassword()) {
            
            $http({
                method: 'POST',
                url: '/XpanelAdmin/UpdatePassword/',
                data: $scope.staff
            }).then(function successCallback(response) {
                if (response.data == "") {
                    $scope.staff.MessageError = "<br/> - Current Password is incorrect.";
                    $scope.staff.Error = true;
                    $scope.staff.Password = "";
                    $('#newpassword').val("");
                    $('#confirmpass').val("");

                    return;
                }
                else {
                    $scope.staff.MessageSuccess = "<br/> - Your Password Changed successfully.";
                    $scope.staff.Success = true;
                    $scope.staff.Password = "";
                    $('#newpassword').val("");
                    $('#confirmpass').val("");


                }

            }, function errorCallback(response) {

            });
        }
        else {

            $scope.staff.MessageError = $scope.staff.MessageError + "<br> -Please fix validations.";
            $scope.staff.Error = true;

        }

    };

    function CheckValidationPassword() {

        IsError = true;
        if ($scope.staff.Password == "") {
           
            IsError = false;

        }

        else
        {
            if ($('#newpassword').val() != $('#confirmpass').val()) {
            
                $scope.staff.MessageError = $scope.staff.MessageError + "<br> -Password and confirm password doesnot match.";
                IsError = false;
            }
        }

        if ($('#confirmpass').val() == "")
        {
          
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




