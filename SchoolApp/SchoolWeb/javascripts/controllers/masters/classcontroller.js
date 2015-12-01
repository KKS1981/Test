/// <reference path="classcontroller.js" />
var app = angular.module(appname);

app.controllerProvider.register('classController', ['$scope', '$compile', '$state', '$stateParams', 'ajax', function ($scope, $compile, $state, $stateParams, ajax) {
    if ($state.$current.name == "classes") {
        ajax('/SVC/MaterService/GetClassList', {}, { method: 'GET', isArray: true, headers: { Accept: 'application/json' } }, null, function (data) {
            $scope.classes = data
        });
    }
    if ($state.$current.name == 'editclass') {
        var id = $stateParams.id;
        ajax('/SVC/MaterService/GetClass', {}, { method: 'GET', isArray: false, headers: { Accept: 'application/json' } }, { id: id }, function (data) {
            $scope.ClassId = data.ClassId;
            $scope.ClassLabelId = data.ClassLabelId;
            $scope.Section = data.Section;
            $scope.TeacherId = data.TeacherId;
        });
    }
    if ($state.$current.name == "createclass" || $state.$current.name == 'editclass') {
        ajax('/SVC/TeacherService/TeacherList', {}, { method: 'GET', isArray: true, headers: { Accept: 'application/json' } }, null, function (data) {
            $scope.Teachers = data;
        });
        ajax('/SVC/MaterService/GetClassLabels', {}, { method: 'GET', isArray: true, headers: { Accept: 'application/json' } }, null, function (data) {
            $scope.classLabels = data;
        });
    }

    $scope.createClass = function () {
        var obj = {};
        obj.Section = $scope.Section;
        obj.ClassLabelId = $scope.ClassLabelId;
        obj.TeacherId = $scope.TeacherId;
        ajax('/SVC/MaterService/CreateClass', {}, { method: 'POST', headers: { Accept: 'application/json' } }, obj, function (data) {
            $state.go("classes");
        });

    }
    $scope.createclasslabel = function () {
        var data = { Name: $scope.Name, NumericCode: $scope.NumericCode };
        ajax('/SVC/MaterService/CreateClassLabel', {}, { method: 'POST', isArray: false, headers: { Accept: 'application/json' } }, data, function (data) {
            $state.go("createclass");
        });
    }
    $scope.editclass = function () {
        var _class = {};
        _class.ClassId=$scope.ClassId;
        _class.Section=$scope.Section;
        _class.ClassLabelId= $scope.ClassLabelId;
        _class.TeacherId = $scope.TeacherId;
        ajax('/SVC/MaterService/EditClass', {}, { method: 'POST', isArray: false, headers: { Accept: 'application/json' } }, _class, function (data) {
            $state.go("classes");
        });

    }
}]);

function classtable(scope, element, attribute) {
    var a = $(element);
    if (a.hasClass("dataTable")) {
        $(element).dataTable().fnDestroy();
    }
    a.DataTable({
        "createdRow": function (row, data, dataIndex) {
            scope.onrowadd(row);
        },
        data: scope[attribute.data],
        columns: [
            { data: 'Label' },
            { data: 'ClassLablel' },
            { data: 'NumericCode' },
            { data: 'ClassTeacher' },
            { data: 'ID' },
        ],
        "columnDefs": [
            {
                "render": function (data, type, row) {
                    return "<a class='fa fa-edit compile' title='edit' ui-sref='editclass(" + JSON.stringify({ id: data }) + ")' href='#/editclass/{ID}'></a>";
                },
                "targets": 4
            },

        ]
    });

}