// Code goes here

var myApp = angular.module('myApp', ['angularUtils.directives.dirPagination']);

//function MyController($scope) {

//  $scope.currentPage = 1;
//  $scope.pageSize = 10;
//  $scope.meals = [];

//  var dishes = [
//    'noodles',
//    'sausage',
//    'beans on toast',
//    'cheeseburger',
//    'battered mars bar',
//    'crisp butty',
//    'yorkshire pudding',
//    'wiener schnitzel',
//    'sauerkraut mit ei',
//    'salad',
//    'onion soup',
//    'bak choi',
//    'avacado maki'
//  ];

//  for (var i = 1; i <= 100; i++) {
//    var dish = dishes[Math.floor(Math.random() * dishes.length)];
  
//    $scope.meals.push(+ i + ': ' + dish);
//  }
  
//  $scope.pageChangeHandler = function(num) {
//      console.log('meals page changed to ' + num);
//  };
//}



function MyController($scope, $http, personService) {
    $scope.personData = null;

    personService.GetAllRecords().then(function (d) {

        $scope.personData = d.data; // Success
        $scope.currentPage = 1;
        $scope.pageSize = 10;
    
        
        // Delete product details
        $scope.delete = function () {

            var index = document.getElementById('hiddenVal').value;
            var id = document.getElementById('hiddenValId').value;

            $http({
                method: 'Post',
                url: '/XpanelAdmin/Delete/' + id,
            }).then(function successCallback(response) {

                $scope.personData.splice(index, 1);
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


        $scope.person = {
            Id: 0,
            firstname: '',
            lastname: '',
            emailid: '',
            gender: '',
            address1: '',
            address2: '',
            city: '',
            state: '',
            zipcode: '',
            passwordhash: '',
            index: true,
            VisibleInsert: false,
            MessageError: '',
            MessageSuccess: '',
            Error: '',
            Success: ''
        }
        $scope.Edit = function (index, id) {

            window.location.href = '../XpanelAdmin/UserProfile?id=' + id;
            //var myindex = 0;
            //for (var i = 0; i < $scope.personData.length; i++) {
            //    if (id == $scope.personData[i].id) {
            //        myindex = i;
            //    }
            //}
            //$scope.person = {
            //    Id: $scope.personData[myindex].id,
            //    firstname: $scope.personData[myindex].firstname,
            //    lastname: $scope.personData[myindex].lastname,
            //    email: $scope.personData[myindex].email,
            //    gender: "" +$scope.personData[myindex].gender,
            //    dateofbirth: new Date(parseInt($scope.personData[myindex].dateofbirth.replace(/(^.*\()|([+-].*$)/g, ''))).toLocaleDateString(),
            //    phone1: $scope.personData[myindex].phone1,
            //    address: $scope.personData[myindex].address,
            //    address1: $scope.personData[myindex].address1,
            //    city: $scope.personData[myindex].city,
            //    state: $scope.personData[myindex].state,
            //    zipcode: $scope.personData[myindex].zipcode
            //};

            //if($scope.person.phone1=="0")
            //{
            //    $scope.person.phone1 = "";
            //}
            //if ($scope.person.zipcode == "0") {
            //    $scope.person.zipcode = "";
            //}
            //$scope.person.VisibleInsert = true;


        }


        function CheckValidationforsave() {

            var IsError = true;
            $scope.person.MessageError = '';
            if ($scope.person.firstname == "") {
                IsError = false;


            }
            if ($scope.person.lastname == "") {
                IsError = false;


            } if ($('#DateOfBirth').val() == "") {
                IsError = false;


            } if ($scope.person.phone1 == "") {
                IsError = false;


            }
            if ($('#Gender').val() == "") {
                IsError = false;


            }
            if ($scope.person.address == "") {
                IsError = false;


            }

            if ($scope.person.city == "") {
                IsError = false;
            }
            if ($('#State').val() == "") {
                IsError = false;


            }
            if ($scope.person.zipcode == "") {
                IsError = false;


            }
            if ($scope.person.email == "") {
                IsError = false;


            }
            else {
                if (/^\w+([\.-]?\w+)*@@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test($('#txtemail').val())) {

                }
                else {
                    $scope.person.MessageError = $scope.person.MessageError + " Email is invalid.";
                    IsError = false;

                }


            }

            return IsError;


        }

        $scope.Cancel = function () {


            $scope.person.index = true;
            $scope.person.VisibleInsert = false;

        }


        $scope.Update = function () {
            $scope.person.Error = false;
            if (CheckValidationforsave()) {

                $http({

                    method: 'POST',
                    url: '/XpanelAdmin/UpdatePerson',
                    data: $scope.person
                }).then(function successCallback(response) {
                    personService.GetAllRecords().then(function (d) {
                        $scope.personData = d.data;
                    });
                    $scope.person.MessageSuccess = "  Record Update Successfully.";
                    $scope.person.Success = true;
                    $scope.person.index = true;
                    $scope.person.VisibleInsert = false;


                },
                function errorCallback(response) {

                    alert("Error : " + response.data.ExceptionMessage);
                });

            }
            else {

                $scope.person.MessageError = $scope.person.MessageError + "  Please Fix Validations.";
                $scope.person.Error = true;

            }


        }




        $scope.Cancel = function () {
            $scope.person.index = true;
            $scope.person.VisibleInsert = false;
        }





        $scope.ChangeStatus = function (id, status) {


            $http
                ({
                    method: 'Post',
                    url: '/XpanelAdmin/ChangeStatus?id=' + id + "&status=" + status,
                }).then(function successCallback(response) {
                    personService.GetAllRecords().then(function (d) {
                        $scope.personData = d.data;
                    });
                    $scope.person.MessageSuccess = $scope.person.MessageError + "  Record Updated Successfully."
                    $scope.person.Success = true;


                }, function errorCallback(response) {
                    alert("Error : " + response.data.ExceptionMessage);
                });


        }

        $scope.exporttoexcel = function () {
            alasql.fn.datetime = function (dateStr) {
                var date = new Date(parseInt(dateStr.replace(/(^.*\()|([+-].*$)/g, ''))).toLocaleDateString();
                if (date.toLocaleString() == 'Invalid Date') {
                    return '';
                }
                return date.toLocaleString();
            };
            alasql.fn.validGender = function (genderStr) {
                var retVal = '';
                if (genderStr == '1') {
                    retVal = 'Male';
                } else if (genderStr == '2') {
                    retVal = 'Female';
                } else {
                    retVal = 'Transgender';
                }
                return retVal;
            };
            alasql('SELECT firstname as FirstName,lastname as LastName,datetime(dateofbirth) as [Date OF Birth],validGender(gender) as Gender,email as Email,phone1 as Phone1,active as Active,address as [Address1],address1 as [Address2],zipcode as ZipCode,state as State,city as City INTO XLSX("PatientList.xlsx",{headers:true}) FROM ?', [$scope.personData]);
        };





    }
    )
}
myApp.factory('personService', function ($http) {
    var fac = {};
    fac.GetAllRecords = function () {
        alert();
        return $http.get('/XpanelAdmin/GetAll');
    }
    return fac;
});
function OtherController($scope) {
  $scope.pageChangeHandler = function(num) {
    console.log('going to page ' + num);
  };
}

myApp.controller('MyController', MyController);
myApp.controller('OtherController', OtherController);