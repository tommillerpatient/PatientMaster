//var app = angular.module('demoModule', ['ngSanitize']);
var app = angular.module('demoModule', ['ui.bootstrap', 'ngResource']);
// Defining angularjs Controller and injecting personService
app.controller('demoCtrl', function ($scope, $http, personService) {

    $scope.staffData = null;
    personService.GetAllRecords().then(function (d) {

        $scope.staffData = d.data; // Success
        $scope.predicate = 'firstname';
        $scope.reverse = true;
        $scope.currentPage = 1;
        $scope.order = function (predicate) {
            $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : false;
            $scope.predicate = predicate;
        };

        $scope.totalItems = $scope.staffData.length;
        $scope.numPerPage = 10;
        $scope.paginate = function (value) {
            var begin, end, index;
            begin = ($scope.currentPage - 1) * $scope.numPerPage;
            end = begin + $scope.numPerPage;
            index = $scope.staffData.indexOf(value);
            return (begin <= index && index < end);
        };
    });
      

    $scope.staff = {
        Id: '',
        EmailId: '',
        Password: '',
        FirstName: '',
        LastName:'',
        MessageError: '',
        MessageSuccess: '',
        Error: false,
        Success: false,
        VisibleInsert:false,
        VisibleIndex: true,
        Insertbutton: true,
        Updatebutton:false,
        createstaff: true,
        Editstaff:false,
    };

    $scope.Add=function()
    {
        $scope.staff.VisibleInsert = true;
        $scope.staff.createstaff = true;
        $scope.staff.Insertbutton = true;
        $scope.staff.VisibleIndex = false;
        $scope.staff.Editstaff = false;
        $scope.staff.Updatebutton = false;
    }



    $scope.Edit = function (index,id)
    {
        var myindex = 0;
        for (var i = 0; i < $scope.staffData.length; i++) {
            if (id == $scope.staffData[i].id)
            {
                myindex = i;
            }
        }
        $scope.staff = {
            Id: $scope.staffData[myindex].id,
            FirstName: $scope.staffData[myindex].firstname,
            LastName: $scope.staffData[myindex].lastname,
            EmailId: $scope.staffData[myindex].emailid,
            Password: $scope.staffData[myindex].password
        };
        $scope.staff.Updatebutton = true;
        $scope.staff.Insertbutton = false;
        $scope.staff.createstaff = false;
        $scope.staff.Editstaff = true;
        $scope.staff.VisibleInsert = true;

    }
    $scope.Cancel = function () {
        $scope.staff.VisibleIndex = true;
        $scope.staff.VisibleInsert = false;
    }

 
    // Reset person details
    $scope.clear = function () {
        $scope.staff.Id = '';
        $scope.staff.EmailId = '';
        $scope.staff.Password = '';
        $scope.staff.FirstName = '';
        $scope.staff.LastName = '';
       
    }

    //Login
    $scope.SignIn = function () {
        $scope.staff.Error = false;
        if (CheckValidation()) {
         
            $http({

                method: 'POST',
                url: '/XpanelAdmin/CheckUserPass',
                data: $scope.staff
            }).then(function successCallback(response) {

                if (response.data == "") {
                    $scope.staff.MessageError = "Email-Id or Password is incorrect.";
                    $scope.staff.Error = true;
                    $scope.clear();
                    return;

                }
                else
                {
                    window.location.href = "../XpanelAdmin/UserList";
                }


            }, function errorCallback(response) {

                alert("Error : " + response.data.ExceptionMessage);
            });

        }
        else {
   
            $scope.staff.MessageError = $scope.staff.MessageError+"Please fix validations."
            $scope.staff.Error = true;
            $scope.clear();

        }




    };



    function CheckValidation() {

        var IsError = true;
        $scope.staff.MessageError = '';

        if ($scope.staff.Email == "") {

           
            IsError = false;
        }
        else
        {

            if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test($('#txtemail').val()))
            {
            }
            else
            {
                $scope.staff.MessageError = $scope.staff.MessageError + "-Email is invalid.";
                IsError = false;
            }


        }


        
        if ($scope.staff.Password == "")
        {
         
            IsError = false;

        }


        return IsError;

    }



    function CheckValidationforsave() {
    
        var IsError = true;

        $scope.staff.MessageError = '';

        if ($scope.staff.FirstName == "")
        {
            $scope.staff.MessageError = $scope.staff.MessageError + "<br> -FirstName is required..";
            IsError = false;

        }
        if ($scope.staff.LastName == "")
        {
            $scope.staff.MessageError = $scope.staff.MessageError + "<br> -LastName is required..";
            IsError = false;

        }
        if ($scope.staff.EmailId == "") {

            $scope.staff.MessageError = $scope.staff.MessageError + "<br> -EmailId is required.";
            IsError = false;
        }
        else
        {

            if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test($('#Email').val())) {



            }

            else {
                $scope.staff.MessageError = $scope.staff.MessageError + "<br> -Email is invalid.";
                IsError = false;
            }


        }

        if ($scope.staff.Password == "") {
            $scope.staff.MessageError = $scope.staff.MessageError + "<br> -Password is required..";
            IsError = false;

        }


        return IsError;

    }


    $scope.Insert=function()
    {
        $scope.staff.Error = false;

        if (CheckValidationforsave())
        {

            $http({

                method: 'POST',
                url: '/XpanelAdmin/Insert',
                data: $scope.staff
            }).then(function successCallback(response)
            {
                $scope.staff.MessageSuccess = "Record Inserted Successfully.";
                $scope.staff.Success = true;
                $scope.clear();
            },
            function errorCallback(response) {

                alert("Error : " + response.data.ExceptionMessage);
            });

        }
        else {

            $scope.staff.MessageError = "Please Fix Validations.";
            $scope.staff.Error = true;
            $scope.clear();

        }


    }

    $scope.Update = function () {
        $scope.staff.Error = false;
        if (CheckValidationforsave()) {

            $http({

                method: 'POST',
                url: '/XpanelAdmin/Update',
                data: $scope.staff
            }).then(function successCallback(response) {

                $scope.staff.MessageSuccess = "Record Update Successfully.";
                $scope.staff.Success = true;
                $scope.staff.VisibleIndex = true;
                $scope.staff.VisibleInsert = false;
                $scope.clear();
                alert($scope.staff.MessageSuccess);
            },
            function errorCallback(response) {

                alert("Error : " + response.data.ExceptionMessage);
            });

        }
        else {

            $scope.staff.MessageError = "Please Fix Validations.";
            $scope.staff.Error = true;
            $scope.clear();

        }


    }



    // Delete product details
    $scope.delete = function () {


        var index = document.getElementById('hiddenVal').value;
        var id = document.getElementById('hiddenValId').value;

        $http({
            method: 'Post',
            url: '/XpanelAdmin/DeleteStaff/' + id,
        }).then(function successCallback(response) {


            $scope.staffData.splice(index, 1);
            document.getElementById('success').style.display = "block";
            $("#dialog-confirm").dialog("close");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });


    };

    $scope.deletepopup = function (index, id) {

        $('#hiddenVal').val(index);

        $('#hiddenValId').val(id);



        $("#dialog-confirm").dialog("open");
    }
    $scope.cancel = function (index) {


        $("#dialog-confirm").dialog("close");
    }

});

// Here I have created a factory which is a populer way to create and configure services. You may also create the factories in another script file which is best practice.
// You can also write above codes for POST,PUT,DELETE in this factory instead of controller, so that our controller will look clean and exhibits proper Separation of Concern.
app.factory('personService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get('/XpanelAdmin/staffData');
    }
    return fac;
});