
//var app = angular.module('demoModule', ['ui.bootstrap', 'ngResource', 'ngSanitize']);
var myApp = angular.module('myApp', ['angularUtils.directives.dirPagination']);


function MyController($scope, $http, personService) {

    $scope.ArticleTitleData = null;

    personService.GetAllRecords().then(function (d) {

        $scope.ArticleTitleData = d.data; // Success
        $scope.currentPage = 1;
        $scope.pageSize = 10;

    });


    $scope.Article = {
        titleid: '',
        title: '',
        MessageError: '',
        MessageSuccess: '',
        Error: false,
        Success: false,
        VisibleInsert: false,
        VisibleIndex: true,
        Insertbutton: true,
        Updatebutton: false,
        createarticle: true,
        Editarticle: false,
    };

    $scope.Add = function () {
        $scope.clear();
        $scope.Article.VisibleInsert = true;
        $scope.Article.createarticle = true;
        $scope.Article.Insertbutton = true;
        $scope.Article.VisibleIndex = false;
        $scope.Article.Editarticle = false;
        $scope.Article.Updatebutton = false;
    }



    $scope.Edit = function (index, id) {
        var myindex = 0;
        for (var i = 0; i < $scope.ArticleTitleData.length; i++) {
            if (id == $scope.ArticleTitleData[i].titleid) {
                myindex = i;
            }
        }
        $scope.Article = {
            titleid: $scope.ArticleTitleData[myindex].titleid,
            title: $scope.ArticleTitleData[myindex].title,

        };
        $scope.Article.Updatebutton = true;
        $scope.Article.Insertbutton = false;
        $scope.Article.createarticle = false;
        $scope.Article.Editarticle = true;
        $scope.Article.VisibleInsert = true;

    }
    $scope.Cancel = function () {
        $scope.Article.VisibleIndex = true;
        $scope.Article.VisibleInsert = false;
        $scope.clear();
        $scope.Article.MessageError = '';
        $scope.Article.MessageSuccess = '';
        $scope.Article.Success = false;
        $scope.Article.Error = false;
    }


    // Reset person details
    $scope.clear = function () {
        $scope.Article.titleid =0;
        $scope.Article.title = '';



    }





    function CheckValidation() {

        var IsError = true;
        $scope.Article.MessageError = '';

        if ($scope.Article.title == "") {


            IsError = false;
        }
        return IsError;

    }



   


    $scope.Insert = function () {
        $scope.Article.Error = false;

        if (CheckValidation()) {

            $http({

                method: 'POST',
                url: '/XpanelArticleTitle/Insert',
                data: $scope.Article
            }).then(function successCallback(response) {
                personService.GetAllRecords().then(function (d) {
                    $scope.ArticleTitleData = d.data;
                });
                $scope.Article.MessageSuccess = "  Record Inserted Successfully.";
                $scope.Article.Success = true;
                $scope.Article.VisibleIndex = true;
                $scope.Article.VisibleInsert = false;
                document.getElementById('divsuccess').style.display = "block";
                $scope.clear();
            },
            function errorCallback(response) {

                alert("Error : " + response.data.ExceptionMessage);
            });

        }
        else {

            $scope.Article.MessageError = $scope.Article.MessageError + "<br> -Please Fix Validations.";
            $scope.Article.Error = true;
            document.getElementById('diverror').style.display = "block";
            ;

        }


    }

    $scope.Update = function () {
        $scope.Article.Error = false;
        if (CheckValidation()) {

            $http({

                method: 'POST',
                url: '/XpanelArticleTitle/Update',
                data: $scope.Article
            }).then(function successCallback(response) {
                personService.GetAllRecords().then(function (d) {
                    $scope.ArticleTitleData = d.data;
                });

                $scope.Article.MessageSuccess = "Record Update Successfully.";
                document.getElementById('divsuccess').style.display = "block";
                $scope.Article.Success = true;
                $scope.Article.VisibleIndex = true;
                $scope.Article.VisibleInsert = false;
                $scope.clear();


            },
            function errorCallback(response) {

                alert("Error : " + response.data.ExceptionMessage);
            });

        }
        else {

            $scope.Article.MessageError = "<br> -Please Fix Validations.";
            $scope.Article.Error = true;
            document.getElementById('diverror').style.display = "block";


        }


    }



    // Delete product details
    $scope.delete = function () {


        var index = document.getElementById('hiddenVal').value;
        var id = document.getElementById('hiddenValId').value;

        $http({
            method: 'Post',
            url: '/XpanelArticleTitle/DeleteArticle/' + id,
        }).then(function successCallback(response) {


            $scope.ArticleTitleData.splice(index, 1);
            $scope.Article.Success = true;
            $scope.Article.MessageSuccess = " Record Deleted Successfully.";
            document.getElementById('divsuccess').style.display = "block";
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

};

// Here I have created a factory which is a populer way to create and configure services. You may also create the factories in another script file which is best practice.
// You can also write above codes for POST,PUT,DELETE in this factory instead of controller, so that our controller will look clean and exhibits proper Separation of Concern.
myApp.factory('personService', function ($http) {
    var fac = {};

    fac.GetAllRecords = function () {
        return $http.get('/XpanelArticleTitle/ArticleData');
    }
    return fac;
});


function OtherController($scope) {
    $scope.pageChangeHandler = function (num) {
        console.log('going to page ' + num);
    };
}

myApp.controller('MyController', MyController);
myApp.controller('OtherController', OtherController);
