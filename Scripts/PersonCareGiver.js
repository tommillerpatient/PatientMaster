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
            HasCareGiver: $scope.personData[0].HasCareGiver,
            Error: false,
            Success: false
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
        if ($scope.person.HasCareGiver == '0' && $scope.person.HasCareGiver == '') {
            //$("#dialog_CareGiver").dialog("open");
        } else {
           // $("#dialog_CareGiver").dialog("close");
        }

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
        //alert('Error Occured !!!'); // Failed
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
        CareGiver: 0,
        HasCareGiver: 0,

    };



    //Add New Item
    $scope.Yes = function () {
        $("#dialog_CareGiver").dialog("close");
        //alert('Yes '+$scope.person.CareGiver);
        window.location.href = '/Account/CareGiverRegister';

    };

    //Login
    $scope.No = function () {
        $("#dialog_CareGiver").dialog("close");


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

        }


        if ($('#Gender').val() == "") {
            $('#Gender').addClass('ng-dirty');
            $('#Gender').addClass('ng-invalid');
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
        //if ($('#Procedure').val() == "") {
        //    $('#Procedure').addClass('ng-dirty');
        //    $('#Procedure').addClass('ng-invalid');
        //    IsError = false;

        //}
        //if ($scope.person.InsuranceCompanyName == "") {

        //    $('#InsuranceCompanyName').addClass('ng-dirty');
        //    $('#InsuranceCompanyName').addClass('ng-invalid');
        //    IsError = false;
        //}
        //if ($scope.person.GroupNumber == "") {
        //    $('#GroupNumber').addClass('ng-dirty');
        //    $('#GroupNumber').addClass('ng-invalid');
        //    IsError = false;

        //}

        //if ($('#ProcedureDate').val() == "") {

        //    $('#ProcedureDate').addClass('ng-dirty');
        //    $('#ProcedureDate').addClass('ng-invalid');

        //    IsError = false;
        //}
        //else
        //{
        //    $('#ProcedureDate').removeClass('ng-dirty');
        //    $('#ProcedureDate').removeClass('ng-invalid');
        //}
        //if ($('#InsuranceEffectiveDate').val() == "") {

        //    $('#InsuranceEffectiveDate').addClass('ng-dirty');
        //    $('#InsuranceEffectiveDate').addClass('ng-invalid');

        //    IsError = false;
        //}
        //else {
        //    $('#InsuranceEffectiveDate').removeClass('ng-dirty');
        //    $('#InsuranceEffectiveDate').removeClass('ng-invalid');
        //}

        //if ($scope.person.PolicyNumber == "") {
        //    $('#PolicyNumber').addClass('ng-dirty');
        //    $('#PolicyNumber').addClass('ng-invalid');

        //    IsError = false;
        //}

        //if ($('#Guarantor').val() == "") {

        //    $('#Guarantor').addClass('ng-dirty');
        //    $('#Guarantor').addClass('ng-invalid');
        //    IsError = false;
        //}
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
        //if ($scope.person.PharmacyAddress2 == "") {
        //    $('#PharmacyAddress2').addClass('ng-dirty');
        //    $('#PharmacyAddress2').addClass('ng-invalid');
        //    IsError = false;

        //}

        if ($scope.person.PharmacyState == "") {
            $('#PharmacyState').addClass('ng-dirty');
            $('#PharmacyState').addClass('ng-invalid');
            IsError = false;

        }


        return IsError;

    }

    function GetUserProgress()
    {


        $scope.UserProgressData = null;

        $http({
            method: 'POST',
            url: '/Account/GetUserProgress/',
            data: {}
        }).then(function successCallback(response) {
            $scope.UserProgressData = response.data;
            for(var i=0;i<response.data.length;i++)
            {
                if ($scope.UserProgressData[i].contentid == 7)
                {
                  
                    $('#pulmonaryli').css('list-style-image', 'url(/Content/assets/images/dot_green.png)');
                }
              else  if ($scope.UserProgressData[i].contentid == 8) {

                  $('#cardiologyli').css('list-style-image', 'url(/Content/assets/images/dot_green.png)');
              }
              else if ($scope.UserProgressData[i].contentid == 9) {

                  $('#upperli').css('list-style-image', 'url(/Content/assets/images/dot_green.png)');
              }
              else if ($scope.UserProgressData[i].contentid == 10) {

                  $('#psycologicalli').css('list-style-image', 'url(/Content/assets/images/dot_green.png)');
              }
              else if ($scope.UserProgressData[i].contentid == 12) {

                  $('#sleepstudyli').css('list-style-image', 'url(/Content/assets/images/dot_green.png)');
              }
              else if ($scope.UserProgressData[i].contentid == 14) {

                  $('#pulmonaryfunctionli').css('list-style-image', 'url(/Content/assets/images/dot_green.png)');
              }
              else if ($scope.UserProgressData[i].contentid == 15) {

                  $('#pulmonologistclrli').css('list-style-image', 'url(/Content/assets/images/dot_green.png)');
              }

              else if ($scope.UserProgressData[i].contentid == 3) {

                  $('#bloodworkli').css('list-style-image', 'url(/Content/assets/images/dot_green.png)');
              }
                else if ($scope.UserProgressData[i].contentid == 4)
                {
                  
                    $('#chestxryli').css('list-style-image', 'url(/Content/assets/images/dot_green.png)');
                }
                else if ($scope.UserProgressData[i].contentid == 5)
                {

                    $('#nutritionli').css('list-style-image', 'url(/Content/assets/images/dot_green.png)');
                }
                else if ($scope.UserProgressData[i].contentid == 6)
                {
                    $('#suprtgroupli').css('list-style-image', 'url(/Content/assets/images/dot_green.png)');
                }


            }
        

            var per = response.data.length;
            var percentage = (per * 8) / 100;
            var percentg = parseInt(percentage * 100);
            $('#per').text(percentg + "% OF JOURNEY COMPLETED");
            $('#progr').css('width', percentg+'%');
        }, function errorCallback(response) {

        });
    }



    $scope.UpdateUserProgress=function(str)
    {
        contentid = '';
        if (str == 'pulmonaryeve')
        {

            contentid = 7;
        }
        else if(str=='chestxry')
        {
            contentid = 4;

        }
        else if (str == 'nutrition')
        {

            contentid = 5;
        }
        else if (str == 'suprtgroup')
        {
            contentid = 6;

        }
        else if (str == 'bloodwork') {
            contentid = 3;

        }
        else if (str == 'cardiology') {

            contentid = 8;
        }

        else if (str == 'upper') {
            contentid = 9;

        }
        else if (str == 'psycological') {
            contentid = 10;

        }
        else if (str == 'sleep') {
            contentid = 12;

        }
        else if (str == 'function') {
            contentid = 14;

        }
        else if (str == 'clearance') {
            contentid = 15;

        }
        $http({
            method: 'POST',
            url: '/Account/UpdateUserProgress/'+contentid,
            data: {}
        }).then(function successCallback(response) {
           
        }, function errorCallback(response) {

        });

    }




    GetUserProgress()

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