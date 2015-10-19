/// <reference path="classcontroller.js" />
var app = angular.module(appname);

app.controllerProvider.register('classController', ['$scope', '$compile', '$state', 'ajax', function ($scope, $compile, $state, ajax) {
    if ($state.$current.name == "classes") {
        ajax('/SVC/MaterService/GetClassList', {}, { method: 'GET', isArray: true, headers: { Accept: 'application/json' } }, null, function (data) {
            $scope.classes = data
        });
    }
    if ($state.$current.name == "createclass") {
        ajax('/SVC/TeacherService/TeacherList', {}, { method: 'GET', isArray: true, headers: { Accept: 'application/json' } }, null, function (data) {
            $scope.Teachers = data;
        });
        ajax('/SVC/MaterService/GetClassLabels', {}, { method: 'GET', isArray: true, headers: { Accept: 'application/json' } }, null, function (data) {
            $scope.Classes = data;
        });
    }

    $scope.createClass = function () { }
    $scope.createclasslabel = function () {
        var data = { Name: $scope.Name, NumericCode: $scope.NumericCode };
        ajax('/SVC/MaterService/CreateClassLabel', {}, { method: 'POST', isArray: false, headers: { Accept: 'application/json' } }, data, function (data) {
            $state.go("createclass");
        });
    }
}]);