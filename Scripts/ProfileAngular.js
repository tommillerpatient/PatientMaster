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

        // alert($scope.personData[0].insuranceeffectivedate);
        $scope.person = {
            Id: $scope.personData[0].id,
            FirstName: $scope.personData[0].firstname,
            LastName: $scope.personData[0].lastname,
            DateOfBirth: new Date(parseInt($scope.personData[0].dateofbirth.replace(/(^.*\()|([+-].*$)/g, ''))).toLocaleDateString(),
            Gender: "" + $scope.personData[0].gender,
            Email: $scope.personData[0].email,
            Phone1: $scope.personData[0].phone1,
            Address: $scope.personData[0].address,
            State: $scope.personData[0].state,
            City: $scope.personData[0].city,
            ZipCode: $scope.personData[0].zipcode,
            Procedure: $scope.personData[0].procedure,
            ProcedureDate: new Date(parseInt($scope.personData[0].proceduredate.replace(/(^.*\()|([+-].*$)/g, ''))).toLocaleDateString(),
            InsuranceCompanyName: $scope.personData[0].insurancecompanyname,
            InsuranceEffectiveDate: new Date(parseInt($scope.personData[0].insuranceeffectivedate.replace(/(^.*\()|([+-].*$)/g, ''))).toLocaleDateString(),
            Guarantor: parseInt($scope.personData[0].guarantor),
            GroupNumber: $scope.personData[0].groupnumber,
            PolicyNumber: parseInt($scope.personData[0].policynumber),
            PreferredPharmacy: $scope.personData[0].preferredpharmacy,
            PharmacyPhone: parseInt($scope.personData[0].pharmacyphone),
            PharmacyAddress1: $scope.personData[0].pharmacyaddress1,
            PharmacyAddress2: $scope.personData[0].pharmacyaddress2,
            PharmacyCity: $scope.personData[0].pharmacycity,
            PharmacyState: $scope.personData[0].pharmacystate,
            CareGiver: $scope.personData[0].CareGiver,
            Error: false,
            Success: false,

        };
        if ($scope.person.ZipCode == '0') {
            $scope.person.ZipCode = '';
        }
        if ($scope.person.phone1 == '0') {
            $scope.person.phone1 = '';
        }
        if ($scope.person.Phone1 == '0') {
            $scope.person.Phone1 = '';
        }
        if ($scope.person.Phone2 == '0') {
            $scope.person.Phone = '';
        }
        if ($scope.person.Phone3 == '0') {
            $scope.person.Phone3 = '';
        }
        //if ($scope.person.DateOfBirth.indexOf("01/01/1900") < 1) {
        //    $scope.person.DateOfBirth = '';
        //}
        //if ($scope.person.ProcedureDate.indexOf("01/01/1900") < 1) {
        //    $scope.person.ProcedureDate = '';
        //}
        //if ($scope.person.InsuranceEffectiveDate.indexOf("01/01/1900") < 1) {
        //    $scope.person.InsuranceEffectiveDate = '';
        //}
        if ($("#ProcedureDate").attr('type') == 'text') {
            if ($scope.personData[0].proceduredate.replace(/(^.*\()|([+-].*$)/g, '') == '') {
                $scope.person.ProcedureDate = null;// new Date('01/01/1900').toLocaleDateString();
            } else
                $scope.person.ProcedureDate = new Date($scope.person.ProcedureDate).toLocaleDateString();
        } else
            $scope.person.ProcedureDate = new Date($scope.person.ProcedureDate).toLocaleDateString();

        if ($("#InsuranceEffectiveDate").attr('type') == 'text') {
            if ($scope.personData[0].insuranceeffectivedate.replace(/(^.*\()|([+-].*$)/g, '') == '') {
                $scope.person.InsuranceEffectiveDate = null;// new Date('01/01/1900').toLocaleDateString();
            } else
                $scope.person.InsuranceEffectiveDate = new Date($scope.person.InsuranceEffectiveDate).toLocaleDateString();
        } else {
            $scope.person.InsuranceEffectiveDate = new Date($scope.person.InsuranceEffectiveDate).toLocaleDateString();
        }
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
        CareGiver:0,
    };


    $scope.keydown = function () {
        $('#DateOfBirth').removeClass('ng-dirty');
        $('#DateOfBirth').removeClass('ng-invalid');
        $('#DateOfBirth').removeClass('ng-invalid-date');
        $('#InsuranceEffectiveDate').removeClass('ng-dirty');
        $('#InsuranceEffectiveDate').removeClass('ng-invalid');
        $('#InsuranceEffectiveDate').removeClass('ng-invalid-date');
        $('#ProcedureDate').removeClass('ng-dirty');

        $('#ProcedureDate').removeClass('ng-invalid-date');

        $('#ProcedureDate').removeClass('ng-invalid');
    }

    $scope.change = function () {
        $('#DateOfBirth').removeClass('ng-dirty');
        $('#DateOfBirth').removeClass('ng-invalid');
        $('#DateOfBirth').removeClass('ng-invalid-date');

        $('#InsuranceEffectiveDate').removeClass('ng-dirty');
        $('#InsuranceEffectiveDate').removeClass('ng-invalid');
        $('#InsuranceEffectiveDate').removeClass('ng-invalid-date');
        $('#ProcedureDate').removeClass('ng-dirty');

        $('#ProcedureDate').removeClass('ng-invalid');
        $('#ProcedureDate').removeClass('ng-invalid-date');

    }
    $scope.keypress = function () {

        $('#DateOfBirth').removeClass('ng-dirty');
        $('#DateOfBirth').removeClass('ng-invalid');
        $('#DateOfBirth').removeClass('ng-invalid-date');
        $('#InsuranceEffectiveDate').removeClass('ng-dirty');
        $('#InsuranceEffectiveDate').removeClass('ng-invalid');
        $('#InsuranceEffectiveDate').removeClass('ng-invalid-date');
        $('#ProcedureDate').removeClass('ng-dirty');

        $('#ProcedureDate').removeClass('ng-invalid');

        $('#ProcedureDate').removeClass('ng-invalid-date');
    }
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
        $scope.person.Error = false;
        $scope.person.Success = false;
        }

    //Add New Item
    $scope.SignUp = function () {
        $scope.person.Error = false;
        if (CheckValidation()) {

            $http({
                method: 'POST',
                url: '/Account/SignUpJson/',
                data: $scope.person
            }).then(function successCallback(response) {

                $scope.clear();

                window.location.href = "../Account/WelcomeBack";
            }, function errorCallback(response) {

            });
        }
        else {

            $scope.person.MessageError = $scope.person.MessageError + "<br> -Please fix validations.";
            $scope.person.Error = true;

        }

    };

    //Login
    $scope.SignIn = function () {

        if ($scope.person.Email != "" && $scope.person.PasswordHash != "") {
            $http({

                method: 'POST',
                url: '/Account/CheckUserPass',
                data: $scope.person
            }).then(function successCallback(response) {

                if (response.data == "") {
                    $scope.person.MessageError = "<br/> -Email-Id or Password is incorrect.";
                    $scope.person.Error = true;
                    $scope.clear();
                    return;

                }
                else {
                    window.location.href = "../Account/WelcomeBack";
                }


            }, function errorCallback(response) {

                alert("Error : " + response.data.ExceptionMessage);
            });

        }
        else {
            $scope.person.MessageError = "<br/> -Email-Id or Password is required.";
            $scope.person.Error = true;
            $scope.clear();

        }




    };
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
        if ($scope.person.Phone1 == "") {
            $('#Phone1').addClass('ng-dirty');
            $('#Phone1').addClass('ng-invalid');

            IsError = false;
        }
        if ($('#DateOfBirth').val() == "") {

            $('#DateOfBirth').addClass('ng-dirty');
            $('#DateOfBirth').addClass('ng-invalid');
            IsError = false;
        }
        else {
            $('#DateOfBirth').removeClass('ng-dirty');
            $('#DateOfBirth').removeClass('ng-invalid');

        }
        if ($scope.person.Email == "") {

            $('#Email').addClass('ng-dirty');
            $('#Email').addClass('ng-invalid');
            IsError = false;
        }
        else {

            if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test($('#Email').val())) {



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

        if ($('#Gender').val() == "") {
            $('#Gender').addClass('ng-dirty');
            $('#Gender').addClass('ng-invalid');
            IsError = false;

        }
        if ($scope.person.PasswordHash == "") {
            $('#PasswordHash').addClass('ng-dirty');
            $('#PasswordHash').addClass('ng-invalid');
            IsError = false;

        }
        else {
            if ($scope.person.PasswordHash != $('#ConfirmPassword').val()) {
                $('#PasswordHash').addClass('ng-dirty');
                $('#PasswordHash').addClass('ng-invalid');
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

        if ($scope.person.Address == "") {
            $('#Address').addClass('ng-dirty');
            $('#Address').addClass('ng-invalid');

            IsError = false;
        }
        if ($('#State').val() == "") {

            $('#State').addClass('ng-dirty');
            $('#State').addClass('ng-invalid');
            IsError = false;
        }
        if ($('#City').val() == "") {
            $('#City').addClass('ng-dirty');
            $('#City').addClass('ng-invalid');
            IsError = false;

        }
        if ($scope.person.ZipCode == "") {

            $('#ZipCode').addClass('ng-dirty');
            $('#ZipCode').addClass('ng-invalid');
            IsError = false;
        }
        if ($('#Procedure').val() == "") {
            $('#Procedure').addClass('ng-dirty');
            $('#Procedure').addClass('ng-invalid');
            IsError = false;

        }
        if ($scope.person.InsuranceCompanyName == "") {

            $('#InsuranceCompanyName').addClass('ng-dirty');
            $('#InsuranceCompanyName').addClass('ng-invalid');
            IsError = false;
        }
        if ($scope.person.GroupNumber == "") {
            $('#GroupNumber').addClass('ng-dirty');
            $('#GroupNumber').addClass('ng-invalid');
            IsError = false;

        }

        if ($('#ProcedureDate').val() == "") {

            $('#ProcedureDate').addClass('ng-dirty');
            $('#ProcedureDate').addClass('ng-invalid');

            IsError = false;
        }
        else {
            $('#ProcedureDate').removeClass('ng-dirty');
            $('#ProcedureDate').removeClass('ng-invalid');
        }
        if ($('#InsuranceEffectiveDate').val() == "") {

            $('#InsuranceEffectiveDate').addClass('ng-dirty');
            $('#InsuranceEffectiveDate').addClass('ng-invalid');

            IsError = false;
        }
        else {
            $('#InsuranceEffectiveDate').removeClass('ng-dirty');
            $('#InsuranceEffectiveDate').removeClass('ng-invalid');
        }

        if ($scope.person.PolicyNumber == "") {
            $('#PolicyNumber').addClass('ng-dirty');
            $('#PolicyNumber').addClass('ng-invalid');

            IsError = false;
        }

        if ($scope.person.Guarantor == "") {

            $('#Guarantor').addClass('ng-dirty');
            $('#Guarantor').addClass('ng-invalid');
            IsError = false;
        }
        if ($scope.person.PreferredPharmacy == "") {

            $('#PreferredPharmacy').addClass('ng-dirty');
            $('#PreferredPharmacy').addClass('ng-invalid');
            IsError = false;
        }

        if ($scope.person.PharmacyAddress1 == "") {
            $('#PharmacyAddress1').addClass('ng-dirty');
            $('#PharmacyAddress1').addClass('ng-invalid');

            IsError = false;
        }

        if ($scope.person.PharmacyCity == "") {

            $('#PharmacyCity').addClass('ng-dirty');
            $('#PharmacyCity').addClass('ng-invalid');
            IsError = false;
        }
        if ($scope.person.PharmacyPhone == "") {
            $('#PharmacyPhone').addClass('ng-dirty');
            $('#PharmacyPhone').addClass('ng-invalid');
            IsError = false;

        }
        if ($scope.person.PharmacyAddress2 == "") {
            $('#PharmacyAddress2').addClass('ng-dirty');
            $('#PharmacyAddress2').addClass('ng-invalid');
            IsError = false;

        }

        if ($scope.person.PharmacyState == "") {
            $('#PharmacyState').addClass('ng-dirty');
            $('#PharmacyState').addClass('ng-invalid');
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
        return $http.get('/Account/GetRecordById');
    }
    return fac;
});