// Defining angularjs module
var app = angular.module('demoModule', ['ngSanitize']);

// Defining angularjs Controller and injecting personService
app.controller('demoCtrl', function ($scope, $http, personService) {

    $scope.personData = null;
    // Fetching records from the factory created at the bottom of the script file
    ///get all record

    personService.GetAllRecords().then(function (d) {
        $scope.personData = d.data; // Success

        $scope.person = {
            Id: $scope.personData[0].id,
            FirstName: $scope.personData[0].firstname,
            LastName: $scope.personData[0].lastname,
            DateOfBirth: new Date(parseInt($scope.personData[0].dateofbirth.replace(/(^.*\()|([+-].*$)/g, ''))),
            Gender: "" + $scope.personData[0].gender,
            Phone1: $scope.personData[0].phone1,
            Address: $scope.personData[0].address,
            Address1: $scope.personData[0].address1,
            State: $scope.personData[0].state,
            City: $scope.personData[0].city,
            ZipCode: $scope.personData[0].zipcode,
            Procedure: $scope.personData[0].procedure,
            ProcedureDate: new Date(parseInt($scope.personData[0].proceduredate.replace(/(^.*\()|([+-].*$)/g, ''))),
            InsuranceCompanyName: $scope.personData[0].insurancecompanyname,
            InsuranceEffectiveDate: new Date(parseInt($scope.personData[0].insuranceeffectivedate.replace(/(^.*\()|([+-].*$)/g, ''))),
            Guarantor: "" + $scope.personData[0].guarantor,
            GroupNumber: $scope.personData[0].groupnumber,
            PolicyNumber: parseInt($scope.personData[0].policynumber),
            PreferredPharmacy: $scope.personData[0].preferredpharmacy,
            PharmacyPhone: $scope.personData[0].pharmacyphone.trim(), //parseInt($scope.personData[0].pharmacyphone.trim().replace('(', '').replace(')', '').replace('-', '').replace(' ', '')),
            PharmacyAddress1: $scope.personData[0].pharmacyaddress1,
            PharmacyAddress2: $scope.personData[0].pharmacyaddress2,
            PharmacyCity: $scope.personData[0].pharmacycity,
            PharmacyState: $scope.personData[0].pharmacystate,
            CareGiver: $scope.personData[0].CareGiver,
            Email: $scope.personData[0].email,
            ProfileImage: $scope.personData[0].profileimage,
            MaritalStatus: $scope.personData[0].maritalstatus,
            Weight: $scope.personData[0].weight,
            Mobile: $scope.personData[0].mobile,
            PreferredCommunication: $scope.personData[0].preferredcommunication,
            SocialNetworks: $scope.personData[0].socialnetworks,
            Language: $scope.personData[0].language,
            Country: $scope.personData[0].Country,
            Error: false,
            Success: false,
            PersonalDetailView: true,
            CommunicationDetailView: true,
            CommunicationDetailEdit: false,
            AddressDetailView: true,
            AddressDetailEdit: false,
        };

        if ($scope.person.Gender = "1") {
            $scope.person.Gender = "Male";

        }
        if ($scope.person.Gender = "2") {
            $scope.person.Gender = "Female";

        }
        if ($scope.person.Gender = "3") {

            $scope.person.Gender = "Transgender";
        }

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

        if ($("#DateOfBirth").attr('type') == 'text') {
            if ($scope.personData[0].dateofbirth.replace(/(^.*\()|([+-].*$)/g, '') == '') {
                $scope.person.DateOfBirth = null;
            } else
                $scope.person.DateOfBirth = new Date($scope.person.DateOfBirth).toLocaleDateString();
        } else
            $scope.person.DateOfBirth = new Date($scope.person.DateOfBirth).toLocaleDateString();


        if ($("#ProcedureDate").attr('type') == 'text') {
            if ($scope.personData[0].proceduredate.replace(/(^.*\()|([+-].*$)/g, '') == '') {
                $scope.person.ProcedureDate = null;
            } else
                $scope.person.ProcedureDate = new Date($scope.person.ProcedureDate).toLocaleDateString();
        } else
            $scope.person.ProcedureDate = new Date($scope.person.ProcedureDate).toLocaleDateString();

        if ($("#InsuranceEffectiveDate").attr('type') == 'text') {
            if ($scope.personData[0].insuranceeffectivedate.replace(/(^.*\()|([+-].*$)/g, '') == '') {
                $scope.person.InsuranceEffectiveDate = null;
            } else
                $scope.person.InsuranceEffectiveDate = new Date($scope.person.InsuranceEffectiveDate).toLocaleDateString();
        } else {
            $scope.person.InsuranceEffectiveDate = new Date($scope.person.InsuranceEffectiveDate).toLocaleDateString();
        }


        $('#PharmacyPhone').val($scope.personData[0].pharmacyphone.trim());

        $('#lblPharmacy').text($scope.personData[0].preferredpharmacy);
        $('#lblPhone').text($scope.personData[0].pharmacyphone.trim());
        $('#lblAddress').text($scope.person.PharmacyAddress1 + ', ' + $scope.person.PharmacyCity + ', ' + $scope.person.PharmacyState);

        if ($scope.personData[0].preferredpharmacy.trim() == '') {
            $('#tblPharmacy').hide();
        } else {
            $('#tblPharmacy').show();
        }

        $('#Procedure').removeAttr('required');



    }, function () {

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
        ActiveCode: '',
        ProfileImage: '',
        PersonalDetailView: true,
        PersonalDetailEdit: false,
        CommunicationDetailView: true,
        CommunicationDetailEdit: false,
        AddressDetailView: true,
        AddressDetailEdit: false,
        MaritalStatus: '',
        Weight: '',
        Mobile: '',
        PreferredCommunication: '',
        SocialNetworks: '',
        Language: '',
        Country: '',
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


    $scope.PersonalCancelEditing = function () {

        $scope.person.PersonalDetailEdit = false;
        $scope.person.PersonalDetailView = true;
        if ($scope.person.Gender = "1") {
            $scope.person.Gender = "Male";

        }
        if ($scope.person.Gender = "2") {
            $scope.person.Gender = "Female";

        }
        if ($scope.person.Gender = "3") {

            $scope.person.Gender = "Transgender";
        }

    }

    $scope.CommunicationCancelEditing = function () {

        $scope.person.CommunicationDetailView = true;
        $scope.person.CommunicationDetailEdit = false;


    }
    $scope.AddressCancelEditing = function () {

        $scope.person.AddressDetailEdit = false;
        $scope.person.AddressDetailView = true;


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
        $scope.person.profileimage = '';
        $scope.person.UnitApt = '';
    }

    $scope.EditPersonDet = function () {

        $scope.person.PersonalDetailView = false;
        $scope.person.PersonalDetailEdit = true;
        if ($scope.person.Gender = "Male") {
            $scope.person.Gender = "1";

        }
        if ($scope.person.Gender = "Female") {
            $scope.person.Gender = "2";

        }
        if ($scope.person.Gender = "Transgender") {

            $scope.person.Gender = "3";
        }
    }

    $scope.EditCommDet = function () {

        $scope.person.CommunicationDetailView = false;
        $scope.person.CommunicationDetailEdit = true;

    }
    $scope.EditAddDet = function () {

        $scope.person.AddressDetailView = false;
        $scope.person.AddressDetailEdit = true;

    }

    $scope.CareGiverEdit = function (index, id) {

        $('#caregiverdiv div.divMyCateGivers:eq(' + index + ')>div.forLabel').hide();
        $('#caregiverdiv div.divMyCateGivers:eq(' + index + ')>div.forEdit').show();


    }
    $scope.CareGiverEditCancel = function (index) {

        $('#caregiverdiv div.divMyCateGivers:eq(' + index + ')>div.forLabel').show();
        $('#caregiverdiv div.divMyCateGivers:eq(' + index + ')>div.forEdit').hide();


    }
    $scope.CareGiver = {

        Id: 0,
        firstname: '',
        lastname: '',
        email: '',
        gender: '',
        genderVal: '',
        CareGiverDetailView: true,
        CareGiverDetailEdit: false,

    }



    //Add New Item
    $scope.SignUp = function () {

        $scope.person.Error = false;
        $scope.person.ProcedureDate = $('#ProcedureDate').val();
        $scope.person.InsuranceEffectiveDate = $('#InsuranceEffectiveDate').val();

        if (CheckValidation()) {
            $('#signupbtn').addClass('submitLoader');
            $http({
                method: 'POST',
                url: '/Account/SignUpJson/',
                data: $scope.person
            }).then(function successCallback(response) {
                if (response.data == "") {
                    $scope.person.MessageError = "<br/> -This email address is already registered with us.";
                    $scope.person.Error = true;
                    document.location.href = "#Profile1";
                    $('#errorStrong').hide();
                    $('#signupbtn').removeClass('submitLoader');
                } else {
                    $scope.clear();
                    //window.location.href = "../Account/SignIn?msg=submited";
                    $('#Profile1').slideToggle("slow");
                    $('#Profile2').slideToggle("slow");
                }
            }, function errorCallback(response) {
                $('#signupbtn').removeClass('submitLoader');
            });
        } else {
            $scope.person.MessageError = $scope.person.MessageError + "<br> -Please fix validations.";
            $scope.person.Error = true;
            document.location.href = "#Profile1";
        }
    };

    //Login
    $scope.SignIn = function () {

        $scope.person.Error = false;
        $('#mesegid').hide();
        $('#PasswordSendid').hide();
        $('#ResetPassMesegid').hide();
        if ($scope.person.Email != "" && $scope.person.PasswordHash != "") {

            $http({

                method: 'POST',
                url: '/Account/CheckUserPass',
                data: $scope.person
            }).then(function successCallback(response) {

                if (response.data.toLowerCase().indexOf('false') != -1) {
                    $scope.person.MessageError = "<br/> -You are not authorized for login.";
                    $scope.person.Error = true;

                    $scope.clear();
                    return;
                }
                else if (response.data == "") {


                    $scope.person.MessageError = "<br/> -Email-Id or Password is incorrect.";
                    $scope.person.Error = true;

                    $scope.clear();
                    return;
                }
                    //else if (parseInt(response.data.indexOf('Not Active')) >= 0) {
                    //    var myid = (response.data.split(',')[1]).trim();
                    //    window.location.href = '/Account/ActivateAccount/';
                    //    //$scope.person.MessageError = "<br/> -Please active your account from registered email.";
                    //    //$scope.person.Error = true;
                    //    $scope.clear();
                    //    return;
                    //}
                else {

                    var myid = (response.data.split(',')[1]).trim();


                    if (myid == "1") {
                        window.location.href = "../XpanelAdmin/UserList";
                    }
                    else {
                        window.location.href = "../Account/WelcomeBack";

                    }


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

    $scope.GoRegister = function () {
        window.location.href = '/Account/SignUp';
    }

    $scope.ActivateAccount = function () {

        $scope.person.Error = false;
        $('#mesegid').hide();
        $('#PasswordSendid').hide();
        $('#ResetPassMesegid').hide();
        if ($scope.person.ActiveCode != "") {
            $('#activatebtn').addClass('submitLoader');
            $http({
                method: 'POST',
                url: '/Account/ActiveUser',
                data: $scope.person
            }).then(function successCallback(response) {
                $('#activatebtn').removeClass('submitLoader');
                if (parseInt(response.data.indexOf('Exception')) >= 0) {
                    $scope.person.MessageError = "<br/> - " + response.data;
                    $scope.person.Error = true;
                    $scope.clear();
                    return;
                }
                else if (parseInt(response.data.indexOf('Success')) >= 0) {
                    window.location.href = "/Account/UserProfile";
                }
                else if (parseInt(response.data.indexOf('Invalie code')) >= 0) {
                    $scope.person.MessageError = "<br/> - " + response.data;
                    $scope.person.Error = true;
                    $scope.clear();
                    return;
                }
            }, function errorCallback(response) {
                $('#activatebtn').removeClass('submitLoader');
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            $scope.person.MessageError = "<br/> - Code is required.";
            $scope.person.Error = true;
            $scope.clear();
        }
    };

    //Update  Item
    $scope.Update = function () {
        $scope.person.Phone1 = $('#Phone1').val();

       
        $scope.person.DateOfBirth = $('#DateOfBirth').val();

        $("#imgprof").attr('src', $('#area').val());
      

        //$scope.person.PreferredPharmacy = $('#PreferredPharmacy').val();
        //$scope.person.PharmacyAddress1 = $('#PharmacyAddress1').val();
        //$scope.person.PharmacyCity = $('#PharmacyCity').val();
        //$scope.person.PharmacyState = $('#PharmacyState').val();
        //$scope.person.PharmacyPhone = $('#PharmacyPhone').val().trim();


        //$scope.person.ProcedureDate = $('#ProcedureDate').val();
        //$scope.person.InsuranceEffectiveDate = $('#InsuranceEffectiveDate').val();

        $scope.person.Error = false;
        if ($('#area').val() != "") {

            $scope.person.ProfileImage = $('#area').val();
        }
        else {
            $scope.person.ProfileImage = $scope.person.ProfileImage;

        }


        if (CheckValidation()) {
            $scope.PersonalCancelEditing();
            $scope.AddressCancelEditing();
            $scope.CommunicationCancelEditing();
            $.ajax({
                method: 'POST',
                url: '/Account/Update/',
                data: $scope.person,
            }).then(function successCallback(response) {

                document.getElementById('diverror').style.display = "none";
                document.getElementById('divsuccess').style.display = "block";
                $scope.person.MessageSuccess = "<br> -Your profile updated successfully.";
                $scope.person.Success = true;



            }, function errorCallback(response) {
                alert(response);
            });
        }
        else {

            $scope.person.MessageError = $scope.person.MessageError + "<br> -Please fix validations.";
            $scope.person.Error = true;

            $('#diverror').show();
            document.location.href = "#UpdateProfile1";
        }

    };




    //Forgot Password
    $scope.GetPassword = function () {

        $scope.person.MessageError = "";
        $scope.person.Error = false;
        if (CheckEmailValid()) {

            $http({
                method: 'POST',
                url: '/Account/GetPassword/',
                data: $scope.person
            }).then(function successCallback(response) {
                if (response.data == "") {
                    $scope.person.MessageError = $scope.person.MessageError + "<br> -This Email address is not registered with us.";
                    $scope.person.Error = true;

                }
                else {
                    $scope.clear();

                    window.location.href = "../Account/SignIn";
                }

            }, function errorCallback(response) {

            });
        }
        else {


            $scope.person.Error = true;

        }

    };

    //Forgot Password
    $scope.ResetPassword = function () {


        $scope.person.Error = false;
        if (checkValidPass()) {

            $http({
                method: 'POST',
                url: '/Account/ResetUpdatePassword/',
                data: $scope.person
            }).then(function successCallback(response) {


                window.location.href = "../Account/SignIn";

            }, function errorCallback(response) {

            });
        }
        else {

            $scope.person.MessageError = $scope.person.MessageError + "<br> -Please Fix Validations.";
            $scope.person.Error = true;

        }

    };

    $scope.fetchPharmasies = function () {
        getLatLng();


    }

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
        var ErrorForMap = true;
        $scope.person.MessageError = '';

        if (parseInt(window.location.href.toLowerCase().indexOf("/userprofile")) > 0) {
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
                $('#Phone1').css('border-color', 'red');
                IsError = false;
            } else if ($('#Phone1').val() == "") {
                $('#Phone1').addClass('ng-dirty');
                $('#Phone1').addClass('ng-invalid');
                $('#Phone1').css('border-color', 'red');
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
            //if ($scope.person.PreferredPharmacy == "") {
            //    $('#PreferredPharmacy').addClass('ng-dirty');
            //    $('#PreferredPharmacy').addClass('ng-invalid');
            //    IsError = false;
            //    ErrorForMap = false;
            //}

            //if ($scope.person.PharmacyAddress1 == "") {
            //    $('#PharmacyAddress1').addClass('ng-dirty');
            //    $('#PharmacyAddress1').addClass('ng-invalid');
            //    ErrorForMap = false;
            //    IsError = false;
            //}

            //if ($scope.person.PharmacyCity == "") {
            //    $('#PharmacyCity').addClass('ng-dirty');
            //    $('#PharmacyCity').addClass('ng-invalid');
            //    ErrorForMap = false;
            //    IsError = false;
            //}
            //if ($scope.person.PharmacyPhone == "") {
            //    $('#PharmacyPhone').addClass('ng-dirty');
            //    $('#PharmacyPhone').addClass('ng-invalid');
            //    ErrorForMap = false;
            //    IsError = false;
            //}
            //if ($scope.person.PharmacyState == "") {
            //    $('#PharmacyState').addClass('ng-dirty');
            //    $('#PharmacyState').addClass('ng-invalid');
            //    ErrorForMap = false;
            //    IsError = false;
            //}
        }

        if (parseInt(window.location.href.toLowerCase().indexOf("/userprofile")) == -1) {
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

        //if ($scope.person.PharmacyAddress2 == "") {
        //    $('#PharmacyAddress2').addClass('ng-dirty');
        //    $('#PharmacyAddress2').addClass('ng-invalid');
        //    IsError = false;

        //}

        if (ErrorForMap == false) {
            $scope.person.MessageError = $scope.person.MessageError + "<br> - Please select pharmacy from map.";
        }


        return IsError;

    }

    function GetMyCareGivers() {
        $scope.CareGiverData = null;

        $http({
            method: 'POST',
            url: '/XpanelAdmin/GetMyCareGivers/',
            data: {}
        }).then(function successCallback(response) {
            $scope.CareGiverData = response.data;
            $scope.CareGiver.CareGiverDetailView = true;
            $scope.CareGiver.CareGiverDetailEdit = true;





        }, function errorCallback(response) {

        });
    }

    $scope.UpdateCareGiver = function () {

        $scope.person.Error = false;
        if (CheckValidation()) {

            $http({
                method: 'POST',
                url: '/XpanelAdmin/CareGiverProfileUpdate/',
                data: $scope.CareGiverData
            }).then(function successCallback(response) {

                $scope.clear();

                window.location.href = "../XpanelAdmin/WelcomeBack";
            }, function errorCallback(response) {

            });
        }
        else {

            $scope.person.MessageError = $scope.person.MessageError + "<br> -Please fix validations.";
            $scope.person.Error = true;

        }

    };






    GetMyCareGivers();




});



var map;
var infoWindow;
var service;
var addrInfo;

var txtPharmacy;
var txtStreet;
var txtCity;
var txtState;
var txtCountry;
var txtZip;
var txtPhone;
//default value
var lat = '32.7846762';
var lng = '-96.80274639';
var zoomLevel = 15;

function getLatLng() {

    var address = $('#PharmacyZipcode').val();
    if (address == '') {
        return;
    }
    zoomLevel = 15;

    //test:
    var foundZip = false;
    var zipTxt = '';
    $.ajax({
        url: "/Content/ziplatlng.txt",
        async: false,
        dataType: "text",
        success: function (data) {
            zipTxt = data;
        },
        error: function (e) {
            console.log(e);
            alert('Error: ' + e);
        }
    });

    if (zipTxt != '') {
        var start_pos = zipTxt.indexOf('|' + address) + 7;
        if (start_pos >= 7) {
            var end_pos = zipTxt.indexOf('|', start_pos);
            var zipInfo = zipTxt.substring(start_pos, end_pos)
            var aryZip = zipInfo.split(',');
            lat = aryZip[0].trim();
            lng = aryZip[1].trim();
            if (lat != '' && lng != '') {
                foundZip = true;
                initialize();
                return;
            }
        }
    }

    if (!foundZip) {
        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'address': address }, function (results, status) {
            if (status === google.maps.GeocoderStatus.OK) {
                lat = results[0].geometry.location.lat();
                lng = results[0].geometry.location.lng();
                initialize();
            }
            else if (status === google.maps.GeocoderStatus.OVER_QUERY_LIMIT) {
                setTimeout(function () {
                    GeocodeFind(address);
                }, 500);
            }
            else {
                alert("Geocode was not successful for the following reason:" + status);
            }
        });
    }
}

function initialize() {
    $("#dialog-confirm").parent().css('z-index', '99999');
    $("#dialog-confirm").dialog("open");

    var myLatlng = new google.maps.LatLng(lat, lng);
    //alert(myLatlng);
    map = new google.maps.Map(document.getElementById('map-canvas'), {
        center: myLatlng,
        zoom: zoomLevel,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    });

    infoWindow = new google.maps.InfoWindow();
    service = new google.maps.places.PlacesService(map);

    google.maps.event.addListenerOnce(map, 'bounds_changed', performSearch);
    google.maps.event.addListenerOnce(map, 'zoom_changed', performSearch);
}

function performSearch() {
    var request = {
        bounds: map.getBounds(),
        keyword: 'pharmacy',
        type: ['pharmacy']
    };
    service.radarSearch(request, callback);
}

function callback(results, status) {
    if (status != google.maps.places.PlacesServiceStatus.OK
            && zoomLevel == 11) {
        alert('No results found');
        //var txt = $('#nearZip').text() + ': No results found.';
        //$('#nearZip').text(txt);
        return;
    }
    else if (status == google.maps.places.PlacesServiceStatus.ZERO_RESULTS) {
        zoomLevel = (zoomLevel == 15 ? 13 : 11);
        initialize();
        return;
    }

    for (var i = 0, result; result = results[i]; i++) {
        createMarker(result);
    }
}

function removeApostrophe(str) {
    if (typeof str != "string") return str;
    return str.replace("'", "");
}

function removeUnitedStates(str) {
    if (typeof str != "string") return str;
    return str.slice(0, str.lastIndexOf(", United States"))
}

function createMarker(place) {
    var addrFormatted;
    var marker = new google.maps.Marker({
        map: map,
        position: place.geometry.location,
        icon: 'http://www.google.com/intl/en_us/mapfiles/ms/micons/red-dot.png'
    });

    google.maps.event.addListener(marker, 'click', function () {
        service.getDetails(place, function (result, status) {

            if (status != google.maps.places.PlacesServiceStatus.OK) {
                alert(status);
                return;
            }

            txtPharmacy = removeApostrophe(result.name);
            txtPhone = result.formatted_phone_number;
            addrFormatted = removeApostrophe(result.formatted_address);
            addrFormatted = removeUnitedStates(addrFormatted);


            var addrContent = '<div><strong>' + txtPharmacy + '</strong><br />' +
                    addrFormatted + '<br />' + txtPhone + '<br />' +
                    '<button type="button" class="btn zn_sub_button btn-fullcolor btn-xs" style="padding: 1px 1px !important;" onclick="showInfo(\'' + txtPharmacy + '\',\'' + txtPhone + '\',\'' + addrFormatted + '\',\'' + result + '\');">SELECT</button>';

            infoWindow.setContent(addrContent);
            infoWindow.open(map, marker);
        });
    });
}


function GeocodeFind(address) {
    var geocoder = new google.maps.Geocoder();

    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            lat = results[0].geometry.location.lat();
            lng = results[0].geometry.location.lng();
        }
        else if (status === google.maps.GeocoderStatus.OVER_QUERY_LIMIT) {
            setTimeout(function () {
                GeocodeFind(address);
            }, 500);
        }
        else {
            alert("Geocode was not successful for the following reason:" + status);
        }
    });
}

function showInfo(pharm, phone, addr, result) {
    //alert((addr.split(',')[2]).split('')[0]);
    $('#PreferredPharmacy').val(pharm);
    $('#PharmacyAddress1').val(addr.split(',')[0]);
    $('#PharmacyCity').val(addr.split(',')[1]);
    $('#PharmacyState').val(addr.split(',')[2].trim().split(' ')[0]);
    $('#PharmacyPhone').val(phone.trim());//phone.trim().replace('(', '').replace(')', '').replace('-', '').replace(' ', '')

    $('#lblPharmacy').text(pharm);
    $('#lblPhone').text(phone);
    $('#lblAddress').text(addr);
    //$('#divPharmacy').hide();
    infoWindow.close();
    $("#dialog-confirm").dialog("close");

    $('#tblPharmacy').show();


}


app.factory('personService', function ($http) {
    var fac = {};
    $('#diverror').hide();
    fac.GetAllRecords = function () {
        return $http.get('/XpanelAdmin/GetRecordById');
    }
    return fac;
});