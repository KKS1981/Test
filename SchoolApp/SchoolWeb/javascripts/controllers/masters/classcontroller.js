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
            $scope.classLabels = data;
        });
    }

    $scope.createClass = function () {
        var obj = {};
        obj.Section=$scope.Section;
        obj.ClassLabelId=$scope.ClassLabelId;
        obj.TeacherId = $scope.TeacherId;
        ajax('/SVC/MaterService/CreateClass', {}, { method: 'POST',  headers: { Accept: 'application/json' } }, obj, function (data) {
            $state.go("classes");
        });

    }
    $scope.createclasslabel = function () {
        var data = { Name: $scope.Name, NumericCode: $scope.NumericCode };
        ajax('/SVC/MaterService/CreateClassLabel', {}, { method: 'POST', isArray: false, headers: { Accept: 'application/json' } }, data, function (data) {
            $state.go("createclass");
        });
    }
}]);

function classtable(scope, element, attribute) {
    var a = $(element);
    if (a.hasClass("dataTable")) {
        $(element).dataTable().fnDestroy();
    }
    a.DataTable({
        data: scope[attribute.data],
        columns: [
            { data: 'Label' },
            { data: 'ClassLablel' },
            { data: 'NumericCode' },
            { data: 'ClassTeacher' },
            { data: 'ID' },
        ],
        "columnDefs": [
            //{
            //    "render": function (data, type, row) {
            //        if (data) {
            //            return "<i class='fa fa-check-circle'></i>";
            //        }
            //        else {
            //            return "<i class='fa  fa-ban'></i>";
            //        }
            //    },
            //    "targets": 3
            //},
            //{
            //    "render": function (data, type, row) {
            //        if (row.IsCurrent) {
            //            return "";
            //        }
            //        else {
            //            return "<button class='btn btn-primary compile' ng-click='makeActive(" + data + ")'>Make Active</button>";
            //        }
            //    },
            //    "targets": 4
            //},
        ]
    });

}