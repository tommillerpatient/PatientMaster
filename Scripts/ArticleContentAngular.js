
//var app = angular.module('demoModule', ['ui.bootstrap', 'ngResource', 'ngSanitize']);
var myApp = angular.module('myApp', ['angularUtils.directives.dirPagination']);


function MyController($scope, $http, personService) {

    $scope.ArticleContentData = null;

    personService.GetAllRecords().then(function (d) {

        $scope.ArticleContentData = d.data; // Success
        $scope.currentPage = 1;
        $scope.pageSize = 10;

    });


    $scope.ArticleContent = {
        subtitleid:'',
        titleid: '',
        content: '',
        contentname:'',
        MessageError: '',
        MessageSuccess: '',
        Error: false,
        Success: false,
        VisibleInsert: false,
        VisibleIndex: true,
        Insertbutton: true,
        Updatebutton: false,
        createArticleContent: true,
        EditArticleContent: false,
    };

    $scope.Add = function () {
        $scope.clear();
        $scope.ArticleContent.VisibleInsert = true;
        $scope.ArticleContent.createArticleContent = true;
        $scope.ArticleContent.Insertbutton = true;
        $scope.ArticleContent.VisibleIndex = false;
        $scope.ArticleContent.EditArticleContent = false;
        $scope.ArticleContent.Updatebutton = false;
    }



    $scope.Edit = function (index, id) {
        var myindex = 0;
        for (var i = 0; i < $scope.ArticleContentData.length; i++) {
            if (id == $scope.ArticleContentData[i].subtitleid) {
                myindex = i;
            }
        }
        $scope.ArticleContent = {
            subtitleid: $scope.ArticleContentData[myindex].subtitleid,
            titleid: $scope.ArticleContentData[myindex].titleid,
            contentid: $scope.ArticleContentData[myindex].contentid,
            content: $scope.ArticleContentData[myindex].content,
            contentname: $scope.ArticleContentData[myindex].contentname,
        };
     
        CKEDITOR.instances.txtcontent.setData($scope.ArticleContent.content);
        $scope.ArticleContent.Updatebutton = true;
        $scope.ArticleContent.Insertbutton = false;
        $scope.ArticleContent.createArticleContent = false;
        $scope.ArticleContent.EditArticleContent = true;
        $scope.ArticleContent.VisibleInsert = true;

    }
    $scope.Cancel = function () {
        $scope.ArticleContent.VisibleIndex = true;
        $scope.ArticleContent.VisibleInsert = false;
        $scope.clear();
        $scope.ArticleContent.MessageError = '';
        $scope.ArticleContent.MessageSuccess = '';
        $scope.ArticleContent.Success = false;
        $scope.ArticleContent.Error = false;
    }


    // Reset person details
    $scope.clear = function () {
        $scope.ArticleContent.titleid = 0;
        $scope.ArticleContent.subtitleid = 0;
        $scope.ArticleContent.content = '';
        $scope.ArticleContent.contentname = '';


    }





    function CheckValidation() {

        var IsError = true;
        $scope.ArticleContent.MessageError = '';

        if ($scope.ArticleContent.content == "") {
           

            IsError = false;
        }
        return IsError;

    }






    $scope.Insert = function () {

        $scope.ArticleContent.Error = false;
        $scope.ArticleContent.content = CKEDITOR.instances['txtcontent'].getData();
        alert(CKEDITOR.instances['txtcontent'].getData());
        if (CheckValidation()) {

            $http({

                method: 'POST',
                url: '/XpanelArticleContent/Insert',
                data: $scope.ArticleContent
            }).then(function successCallback(response) {
                personService.GetAllRecords().then(function (d) {
                    $scope.ArticleContentData = d.data;
                });
                $scope.ArticleContent.MessageSuccess = "  Record Inserted Successfully.";
                $scope.ArticleContent.Success = true;
                $scope.ArticleContent.VisibleIndex = true;
                $scope.ArticleContent.VisibleInsert = false;
                document.getElementById('divsuccess').style.display = "block";
                $scope.clear();
            },
            function errorCallback(response) {

                alert("Error : " + response.data.ExceptionMessage);
            });

        }
        else {

            $scope.ArticleContent.MessageError = $scope.ArticleContent.MessageError + "<br> -Please Fix Validations.";
            $scope.ArticleContent.Error = true;
            document.getElementById('diverror').style.display = "block";
            ;

        }


    }

    $scope.Update = function () {
        $scope.ArticleContent.Error = false;
        if (CheckValidation()) {

            $http({

                method: 'POST',
                url: '/XpanelArticleContent/Update',
                data: $scope.ArticleContent
            }).then(function successCallback(response) {
                personService.GetAllRecords().then(function (d) {
                    $scope.ArticleContentData = d.data;
                });

                $scope.ArticleContent.MessageSuccess = "Record Update Successfully.";
                document.getElementById('divsuccess').style.display = "block";
                $scope.ArticleContent.Success = true;
                $scope.ArticleContent.VisibleIndex = true;
                $scope.ArticleContent.VisibleInsert = false;
                $scope.clear();


            },
            function errorCallback(response) {

                alert("Error : " + response.data.ExceptionMessage);
            });

        }
        else {

            $scope.ArticleContent.MessageError = "<br> -Please Fix Validations.";
            $scope.ArticleContent.Error = true;
            document.getElementById('diverror').style.display = "block";


        }


    }



    // Delete product details
    $scope.delete = function () {


        var index = document.getElementById('hiddenVal').value;
        var id = document.getElementById('hiddenValId').value;

        $http({
            method: 'Post',
            url: '/XpanelArticleContent/DeleteArticleContent/' + id,
        }).then(function successCallback(response) {


            $scope.ArticleContentData.splice(index, 1);
            $scope.ArticleContent.Success = true;
            $scope.ArticleContent.MessageSuccess = " Record Deleted Successfully.";
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




    $scope.FillTitleSubtitleList = function () {
        $scope.TitleList = null;
        $http({
            method: 'Get',
            url: '/XpanelArticleContent/TitleSubtitleList',
            data: {}
        }).success(function (result) {

            $scope.TitleList = result;

        });
    };


    $scope.FillTitleSubtitleList();

};

// Here I have created a factory which is a populer way to create and configure services. You may also create the factories in another script file which is best practice.
// You can also write above codes for POST,PUT,DELETE in this factory instead of controller, so that our controller will look clean and exhibits proper Separation of Concern.
myApp.factory('personService', function ($http) {
    var fac = {};

    fac.GetAllRecords = function () {
        return $http.get('/XpanelArticleContent/ArticleContentData');
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
