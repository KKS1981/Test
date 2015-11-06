var app = angular.module(appname);
app.controllerProvider.register('teacherController', ['$scope', '$compile', '$state', '$stateParams', 'ajax', function ($scope, $compile, $state, $stateParams, ajax) {
    if ($state.$current.name == "teachers") {
        ajax('/SVC/TeacherService/TeacherViewList', {}, { method: 'GET', isArray: true, headers: { Accept: 'application/json' } }, null, function (data) {
            $scope.teachers = data
        });
    }
    if ($state.$current.name == "createteacher") {
        $scope.info = "basic";
        $scope.heading = "Basic Information";
    }
    $scope.address = function () {
        $scope.formsubmitted = true;
        if ($scope.teacherform.$valid) {
            $scope.info = "address";
            $scope.heading = "Address Information";
            $scope.formsubmitted = false;
        }
    }
    $scope.image = function () {
        $scope.formsubmitted = true;
        if ($scope.teacherform.$valid) {
            $scope.info = "image";
            $scope.heading = "Teacher Picture";
            $scope.formsubmitted = false;
        }
    }
    $scope.basic = function () {
        $scope.info = "basic";
        $scope.heading = "Basic Information";
    }
    $scope.isinvalid = function (data) {
        
        if ($scope.formsubmitted == undefined && !data.$dirty) {
            return false;
        }
        return data.$invalid && (data.$dirty || $scope.formsubmitted);
    }
}
]
)
function teachertable(scope, element, attribute) {
    var a = $(element);
    if (a.hasClass("dataTable")) {
        $(element).dataTable().fnDestroy();
    }
    a.DataTable({
        data: scope[attribute.data],
        columns: [
            { data: 'ImagePath' },
            { data: 'FullName' },
            { data: 'Dob' },
            { data: 'Address' },
            { data: 'ClassTeacher' },
            { data: 'Id' },
        ],
        "columnDefs": [
            {
                "render": function (data, type, row) {
                    return "<a class='fa fa-edit compile' title='edit' ui-sref='editclass(" + JSON.stringify({ id: data }) + ")' href='#/editclass/{ID}'></a>";
                },
                "targets": 5,
                "orderable": false
            },
            {
                "render": function (data, type, row) {
                    var html = "";
                    if (row.MobileNumber != null && row.MobileNumber != "")
                        html = html + "<i class='fa fa-fw fa-mobile-phone'>" + row.MobileNumber + "</i>"
                    if (row.PhoneNumber != null && row.PhoneNumber != "") {
                        html = html + "<br/>" + "<i class='fa fa-fw fa-phone'>" + row.PhoneNumber + "</i>"
                    }
                    return html;
                },
                "targets": 4
            },
            {
                "render": function (data, type, row) {
                    var html = "";
                    if (row.ImagePath != null && row.ImagePath != "")

                        html = html + "<img src='" + row.ImagePath + "' style='width: 50px;'>"
                    else {
                        html = html + "<img src='/images/default-avatar.v9899025.gif' style='width: 50px;'>"
                    }
                    return html;
                },
                "targets": 0,
                "orderable": false
            },
            {
                "render": function (data, type, row) {
                    var html = toDateString(row.Dob);

                    return html;
                },
                "targets": 2
            },


        ]
    });

}

