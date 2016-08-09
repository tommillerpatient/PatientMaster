
// Defining angularjs module
var app = angular.module('demoModule', ['ngSanitize']);

// Defining angularjs Controller and injecting personService
app.controller('demoCtrl', function ($scope, $http, personService) {

    $scope.personData = null;
    // Fetching records from the factory created at the bottom of the script file
    ///get all record

    personService.GetAllRecords().then(function (d) {
        $scope.personData = d.data; // Success
        document.getElementById('diverror').style.display = "block";


        $scope.person = {
            Id: $scope.personData[0].id,
            Address: $scope.personData[0].firstname + ', ' + $scope.personData[0].lastname,
            CareGiver: $scope.personData[0].CareGiver,
            Error: false,
            Success: false,
        };

        

    }, function () {
        alert('Error Occured !!!'); // Failed
    });

    $scope.person = {
        Id: '',
        UserName: '',
        PasswordHash: '',
        SessionToken: '',
        FirstName: '',
        MiddleName: '',
        LastName: '',
        DateOfBirth: '',
        Gender: '',
        Email: '',
        Phone1: '',
        Phone2: '',
        Phone3: '',
        personIsPatient: '',
        AcknowledgedNoticeOfPrivacy: '',
        Address: '',
        Address1: '',
        ZipCode: '',
        State: '',
        City: '',
        Procedure: '',
        ProcedureDate: '',
        InsuranceCompanyName: '',
        InsuranceEffectiveDate: '',
        Guarantor: '',
        GroupNumber: '',
        PolicyNumber: '',
        PreferredPharmacy: '',
        PharmacyPhone: '',
        PharmacyAddress1: '',
        PharmacyAddress2: '',
        PharmacyCity: '',
        PharmacyState: '',
        MessageError: '',
        MessageSuccess: '',
        Error: false,
        Success: false,
        CareGiver: 0,
    };


    // Reset person details
    $scope.clear = function () {
        $scope.person.Id = '';
        $scope.person.UserName = '';
        $scope.person.PasswordHash = '';
        $scope.person.SessionToken = '';
        $scope.person.FirstName = '';
        $scope.person.MiddleName = '';
        $scope.person.LastName = '';
        $scope.person.DateOfBirth = '';
        $scope.person.Gender = '';
        $scope.person.Email = '';
        $scope.person.Phone1 = '';
        $scope.person.Phone2 = '';
        $scope.person.Phone3 = '';
        $scope.person.personIsPatient = '';
        $scope.person.AcknowledgedNoticeOfPrivacy = '';
        $scope.person.Address = '';
        $scope.person.Address1 = '';
        $scope.person.ZipCode = '';
        $scope.person.State = '';
        $scope.person.City = '';
        $scope.person.Procedure = '';
        $scope.person.ProcedureDate = '';
        $scope.person.InsuranceCompanyName = '';
        $scope.person.InsuranceEffectiveDate = '';
        $scope.person.Guarantor = '';
        $scope.person.GroupNumber = '';
        $scope.person.PolicyNumber = '';
        $scope.person.PreferredPharmacy = '';
        $scope.person.PharmacyPhone = '';
        $scope.person.PharmacyAddress1 = '';
        $scope.person.PharmacyAddress2 = '';
        $scope.person.PharmacyCity = '';
        $scope.person.PharmacyState = '';
        $scope.person.CareGiver = 0;
        $scope.person.Error = false,
        $scope.person.Success = false
        }

    //Add New Item
    $scope.SendRequest = function () {
        $scope.person.Error = false;
        if (CheckValidation()) {

            $('#Comentbtn').addClass('submitLoader');

            $http({
                method: 'POST',
                url: '/Account/NewCareGiverJson/',
                data: $scope.person
            }).then(function successCallback(response) {

            
                    $scope.clear();
                    //alert("../Account/MyCareGivers?msg=CareGiver");
                    window.location.href = "../Account/MyCareGivers?msg=CareGiver";
                

            }, function errorCallback(response) {
                $('#signupbtn').removeClass('submitLoader');
            });
        }
        else {

            $scope.person.MessageError = $scope.person.MessageError + "<br> -Please fix validations.";
            $scope.person.Error = true;
            document.location.href = "#Profile1";

        }

    };

    


    function checkValidPass() {

        var IsError = true;
        $scope.person.MessageError = '';

        if ($scope.person.PasswordHash == "") {
            IsError = false;
        }
        else {
            if ($scope.person.PasswordHash != $('#ConfirmPass').val()) {
                $scope.person.MessageError = $scope.person.MessageError + "<br> -Password and confirm password doesnot match.";
                IsError = false;
            }
        }

        if ($('#ConfirmPass').val() == "") {
            IsError = false;
        }

        return IsError;

    }

    function CheckEmailValid() {
        var IsError = true;
        $scope.person.MessageError = '';
        if ($scope.person.Email == "") {
            $scope.person.MessageError = $scope.person.MessageError + "<br> -Email is required.";
            IsError = false;
        }
        else {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (re.test($('#Email').val())) {

            }
            else {
                $scope.person.MessageError = $scope.person.MessageError + "<br> -Email is invalid.";
                IsError = false;
            }
        }

        return IsError;

    }

    function CheckValidation() {

        var IsError = true;
        $scope.person.MessageError = '';

        if ($scope.person.FirstName == "") {

            $('#FirstName').addClass('ng-dirty');
            $('#FirstName').addClass('ng-invalid');

            IsError = false;
        }
        if ($scope.person.LastName == "") {
            $('#LastName').addClass('ng-dirty');
            $('#LastName').addClass('ng-invalid');

            IsError = false;
        }

        if (parseInt(window.location.href.indexOf("/UserProfile")) == -1) {
            if ($scope.person.Email == "") {

                $('#Email').addClass('ng-dirty');
                $('#Email').addClass('ng-invalid');
                IsError = false;
            }
            else {

                var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

                if (re.test($('#Email').val())) {

                }
                else {
                    $scope.person.MessageError = $scope.person.MessageError + "<br> -Email is invalid.";
                    IsError = false;
                }

                if ($scope.person.Email != $('#ConfirmEmail').val()) {
                    $('#Email').addClass('ng-dirty');
                    $('#Email').addClass('ng-invalid');
                    $('#ConfirmEmail').addClass('ng-dirty');
                    $('#ConfirmEmail').addClass('ng-invalid');
                    $scope.person.MessageError = $scope.person.MessageError + "<br> -Email and confirm Email doesnot match.";
                    IsError = false;
                }
            }
            if ($('#ConfirmEmail').val() == "") {
                $('#ConfirmEmail').addClass('ng-dirty');
                $('#ConfirmEmail').addClass('ng-invalid');
                IsError = false;
            }

        }


        return IsError;

    }



});

// Here I have created a factory which is a populer way to create and configure services. You may also create the factories in another script file which is best practice.
// You can also write above codes for POST,PUT,DELETE in this factory instead of controller, so that our controller will look clean and exhibits proper Separation of Concern.
app.factory('personService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get('/Account/GetRecordById');
    }
    return fac;
});