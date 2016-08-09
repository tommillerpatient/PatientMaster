//var app = angular.module('demoModule', ['ngSanitize']);
var app = angular.module('demoModule', ['ui.bootstrap', 'ngResource', 'ngSanitize']);
// Defining angularjs Controller and injecting personService
app.controller('demoCtrl', function ($scope, $http, personService) {

    $scope.appointmentData = null;


    personService.GetAllRecords().then(function (d) {

        $scope.appointmentData = d.data; // Success
        $scope.predicate = 'appointmentname';
        $scope.reverse = true;
        $scope.currentPage = 1;
        $scope.order = function (predicate) {
            $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : false;
            $scope.predicate = predicate;
        };

        $scope.totalItems = $scope.appointmentData.length;
        $scope.numPerPage = 10;
        $scope.paginate = function (value) {
            var begin, end, index;
            begin = ($scope.currentPage - 1) * $scope.numPerPage;
            end = begin + $scope.numPerPage;
            index = $scope.appointmentData.indexOf(value);
            return (begin <= index && index < end);
        };
    });


    $scope.appointment = {
        appointmentId: '',
        appointmentdate: '',
        appointmentdesc: '',
        attendid: '',
        patientid: '',
        appointmentname: '',
        active: false,
        appointmenton: '',
        staffid: '',
        MessageError: '',
        MessageSuccess: '',
        Error: false,
        Success: false,
        VisibleInsert: false,
        VisibleIndex: true,
        Insertbutton: true,
        Updatebutton: false,
        createappointment: true,
        Editappointment: false,
    };

    $scope.Add = function () {
        $scope.clear();
        $scope.appointment.VisibleInsert = true;
        $scope.appointment.createAppointment = true;
        $scope.appointment.Insertbutton = true;
        $scope.appointment.VisibleIndex = false;
        $scope.appointment.EditAppointment = false;
        $scope.appointment.Updatebutton = false;
    }



    $scope.Edit = function (index, id) {
        var myindex = 0;


        for (var i = 0; i < $scope.appointmentData.length; i++) {
            if (id == $scope.appointmentData[i].appointmentid) {
                myindex = i;
            }
        }
        $scope.appointment = {
            appointmentid: $scope.appointmentData[myindex].appointmentid,
            appointmentname: $scope.appointmentData[myindex].appointmentname,
            appointmentdesc: $scope.appointmentData[myindex].appointmentdesc,
            appointmentdate: new Date(parseInt($scope.appointmentData[myindex].appointmentdate.replace(/(^.*\()|([+-].*$)/g, ''))).toLocaleDateString(),
            staffid: $scope.appointmentData[myindex].staffid,
            attendid: $scope.appointmentData[myindex].attendid,
            patientid: $scope.appointmentData[myindex].patientid
        };
        $scope.appointment.Updatebutton = true;
        $scope.appointment.Insertbutton = false;
        $scope.appointment.createappointment = false;
        $scope.appointment.Editappointment = true;
        $scope.appointment.VisibleInsert = true;

    }
    $scope.Cancel = function () {
        $scope.appointment.VisibleIndex = true;
        $scope.appointment.VisibleInsert = false;
        $scope.clear();
        $scope.appointment.MessageError = '';
        $scope.appointment.MessageSuccess = '';
        $scope.appointment.Success = false;
        $scope.appointment.Error = false;
    }


    // Reset person details
    $scope.clear = function () {
        $scope.appointment.appointmentid = '';
        $scope.appointment.appointmentname = '';
        $scope.appointment.appointmentdesc = '';
        $scope.appointment.appointmentdate = '';
        $scope.appointment.patientid = '';
        $scope.appointment.staffid = '';
        $scope.appointment.attendid = '';
        $scope.appointment.active = '';
    }

 







    function CheckValidationforsave() 
    {
  

        var IsError = true;

        $scope.appointment.MessageError = '';

        if ($scope.appointment.appointmentname == "") 
        {
        
            IsError = false;

        }
        if ($scope.appointment.appointmentdesc == "") 
        {
          
            IsError = false;

        }
        if ($('#appointmentdate').val() == "")
        {
           
           
            IsError = false;
        }
     

        if ($('#patientid').val() == "")
            {
           
                IsError = false;
            }


        

    //if ($scope.appointment.staffid == "") 
    //{
           
    //        IsError = false;

    //}


        return IsError;

    }


    $scope.Insert = function () {
        $scope.appointment.Error = false;

        if (CheckValidationforsave()) {
           
            $.ajax({
                method: 'POST',
                url: '/XpanelAppointment/Insert',
                data: $scope.appointment
            }).then(function successCallback(response) {

                personService.GetAllRecords().then(function (d) {
                    $scope.appointmentData = d.data;
                });
                $scope.appointment.MessageSuccess = " Record Inserted Successfully.";
                $scope.appointment.Success = true;
                $scope.clear();
            },
            function errorCallback(response) {

                alert("Error : " + response.data.ExceptionMessage);
            });

        }
        else {

            $scope.appointment.MessageError = $scope.appointment.MessageError+"<br> -Please Fix Validations.";
            $scope.appointment.Error = true;
            $scope.clear();

        }


    }

    $scope.Update = function () {
        $scope.appointment.Error = false;
        if (CheckValidationforsave()) {

            $http({

                method: 'POST',
                url: '/XpanelAppointment/Update',
                data: $scope.appointment
            }).then(function successCallback(response) {
                personService.GetAllRecords().then(function (d) {
                    $scope.appointmentData = d.data;
                });
                $scope.appointment.MessageSuccess = " Record Update Successfully.";
                $scope.appointment.Success = true;
                $scope.appointment.VisibleIndex = true;
                $scope.appointment.VisibleInsert = false;
                $scope.clear();
                
            },
            function errorCallback(response) {

                alert("Error : " + response.data.ExceptionMessage);
            });

        }
        else {

            $scope.appointment.MessageError =   $scope.appointment.MessageError+"<br> -Please Fix Validations.";
            $scope.appointment.Error = true;
          

        }


    }



    // Delete product details
    $scope.delete = function () {


        var index = document.getElementById('hiddenVal').value;
        var id = document.getElementById('hiddenValId').value;

        $http({
            method: 'Post',
            url: '/XpanelAppointment/Delete/' + id,
        }).then(function successCallback(response) {


            $scope.appointmentData.splice(index, 1);
            document.getElementById('success').style.display = "block";

            $('#dialog-confirm').css("display", "none");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });


    };

    $scope.deletepopup = function (index, id) {

        $('#hiddenVal').val(index);

        $('#hiddenValId').val(id);



        $('#dialog-confirm').css("display", "block");
    }
    $scope.cancel = function (index) {


        $('#dialog-confirm').css("display", "none");
    }
    $scope.FillPersonList = function () {
        $scope.PersonList = null;
        $http({
            method: 'Get',
            url: '/XpanelAppointment/PersonList',
            data: {}
        }).success(function (result) {
          
            $scope.PersonList = result;

        });
    };


    $scope.FillPersonList();
});

// Here I have created a factory which is a populer way to create and configure services. You may also create the factories in another script file which is best practice.
// You can also write above codes for POST,PUT,DELETE in this factory instead of controller, so that our controller will look clean and exhibits proper Separation of Concern.
app.factory('personService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        return $http.get('/XpanelAppointment/AppointmentData');
    }
    return fac;
});