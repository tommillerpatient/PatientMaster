
//var app = angular.module('demoModule', ['ui.bootstrap', 'ngResource', 'ngSanitize']);
var myApp = angular.module('myApp', ['angularUtils.directives.dirPagination']);


function MyController($scope, $http, personService) {

    $scope.ArticleSubtitleData = null;

    personService.GetAllRecords().then(function (d) {

        $scope.ArticleSubtitleData = d.data; // Success
        $scope.currentPage = 1;
        $scope.pageSize = 10;

    });


    $scope.ArticleSubtitle = {
        subtitleid:'',
        titleid: '',
        subtitle: '',
        MessageError: '',
        MessageSuccess: '',
        Error: false,
        Success: false,
        VisibleInsert: false,
        VisibleIndex: true,
        Insertbutton: true,
        Updatebutton: false,
        createArticleSubtitle: true,
        EditArticleSubtitle: false,
    };

    $scope.Add = function () {
        $scope.clear();
        $scope.ArticleSubtitle.VisibleInsert = true;
        $scope.ArticleSubtitle.createArticleSubtitle = true;
        $scope.ArticleSubtitle.Insertbutton = true;
        $scope.ArticleSubtitle.VisibleIndex = false;
        $scope.ArticleSubtitle.EditArticleSubtitle = false;
        $scope.ArticleSubtitle.Updatebutton = false;
    }



    $scope.Edit = function (index, id) {
        var myindex = 0;
        for (var i = 0; i < $scope.ArticleSubtitleData.length; i++) {
            if (id == $scope.ArticleSubtitleData[i].subtitleid) {
                myindex = i;
            }
        }
        $scope.ArticleSubtitle = {
            subtitleid: $scope.ArticleSubtitleData[myindex].subtitleid,
            titleid: $scope.ArticleSubtitleData[myindex].titleid,
            subtitle: $scope.ArticleSubtitleData[myindex].subtitle,

        };
        $scope.ArticleSubtitle.Updatebutton = true;
        $scope.ArticleSubtitle.Insertbutton = false;
        $scope.ArticleSubtitle.createArticleSubtitle = false;
        $scope.ArticleSubtitle.EditArticleSubtitle = true;
        $scope.ArticleSubtitle.VisibleInsert = true;

    }
    $scope.Cancel = function () {
        $scope.ArticleSubtitle.VisibleIndex = true;
        $scope.ArticleSubtitle.VisibleInsert = false;
        $scope.clear();
        $scope.ArticleSubtitle.MessageError = '';
        $scope.ArticleSubtitle.MessageSuccess = '';
        $scope.ArticleSubtitle.Success = false;
        $scope.ArticleSubtitle.Error = false;
    }


    // Reset person details
    $scope.clear = function () {
        $scope.ArticleSubtitle.titleid = 0;
        $scope.ArticleSubtitle.subtitleid = 0;
        $scope.ArticleSubtitle.subtitle = '';



    }





    function CheckValidation() {

        var IsError = true;
        $scope.ArticleSubtitle.MessageError = '';

        if ($scope.ArticleSubtitle.subtitle == "") {


            IsError = false;
        }
        return IsError;

    }






    $scope.Insert = function () {
        $scope.ArticleSubtitle.Error = false;

        if (CheckValidation()) {

            $http({

                method: 'POST',
                url: '/XpanelArticleSubtitle/Insert',
                data: $scope.ArticleSubtitle
            }).then(function successCallback(response) {
                personService.GetAllRecords().then(function (d) {
                    $scope.ArticleSubtitleData = d.data;
                });
                $scope.ArticleSubtitle.MessageSuccess = "  Record Inserted Successfully.";
                $scope.ArticleSubtitle.Success = true;
                $scope.ArticleSubtitle.VisibleIndex = true;
                $scope.ArticleSubtitle.VisibleInsert = false;
                document.getElementById('divsuccess').style.display = "block";
                $scope.clear();
            },
            function errorCallback(response) {

                alert("Error : " + response.data.ExceptionMessage);
            });

        }
        else {

            $scope.ArticleSubtitle.MessageError = $scope.ArticleSubtitle.MessageError + "<br> -Please Fix Validations.";
            $scope.ArticleSubtitle.Error = true;
            document.getElementById('diverror').style.display = "block";
            ;

        }


    }

    $scope.Update = function () {
        $scope.ArticleSubtitle.Error = false;
        if (CheckValidation()) {

            $http({

                method: 'POST',
                url: '/XpanelArticleSubtitle/Update',
                data: $scope.ArticleSubtitle
            }).then(function successCallback(response) {
                personService.GetAllRecords().then(function (d) {
                    $scope.ArticleSubtitleData = d.data;
                });

                $scope.ArticleSubtitle.MessageSuccess = "Record Update Successfully.";
                document.getElementById('divsuccess').style.display = "block";
                $scope.ArticleSubtitle.Success = true;
                $scope.ArticleSubtitle.VisibleIndex = true;
                $scope.ArticleSubtitle.VisibleInsert = false;
                $scope.clear();


            },
            function errorCallback(response) {

                alert("Error : " + response.data.ExceptionMessage);
            });

        }
        else {

            $scope.ArticleSubtitle.MessageError = "<br> -Please Fix Validations.";
            $scope.ArticleSubtitle.Error = true;
            document.getElementById('diverror').style.display = "block";


        }


    }



    // Delete product details
    $scope.delete = function () {


        var index = document.getElementById('hiddenVal').value;
        var id = document.getElementById('hiddenValId').value;

        $http({
            method: 'Post',
            url: '/XpanelArticleSubtitle/DeleteArticleSubtitle/' + id,
        }).then(function successCallback(response) {


            $scope.ArticleSubtitleData.splice(index, 1);
            $scope.ArticleSubtitle.Success = true;
            $scope.ArticleSubtitle.MessageSuccess = " Record Deleted Successfully.";
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




    $scope.FillTitleList = function () {
        $scope.TitleList = null;
        $http({
            method: 'Get',
            url: '/XpanelArticleSubtitle/ArticleTitleList',
            data: {}
        }).success(function (result) {

            $scope.TitleList = result;

        });
    };


    $scope.FillTitleList();

};

// Here I have created a factory which is a populer way to create and configure services. You may also create the factories in another script file which is best practice.
// You can also write above codes for POST,PUT,DELETE in this factory instead of controller, so that our controller will look clean and exhibits proper Separation of Concern.
myApp.factory('personService', function ($http) {
    var fac = {};

    fac.GetAllRecords = function () {
        return $http.get('/XpanelArticleSubtitle/ArticleSubtitleData');
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
