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
    if ($state.$current.name == "editteacher") {
        $scope.teacher = {};
        var id = $stateParams.id
        $scope.heading = "Edit Teacher";
        ajax('/SVC/TeacherService/GetEditTeacher', {}, { method: 'GET', isArray: false, headers: { Accept: 'application/json' } }, { "id": id }, function (data) {
            data.Dob = toDateString(data.Dob);
            if (data.Doj != null)
                data.Doj = toDateString(data.Doj);
            $scope.teacher = data

        });
    }
    $scope.address = function () {
        $scope.formsubmitted = true;
        if ($scope.teacherform.$valid) {
            $scope.info = "address";
            $scope.heading = "Address Information";
            $scope.formsubmitted = false;
        }
    }
    $scope.addTeacher = function () {
        if ($scope.teacherform.$valid) {
            var teachercopy = angular.copy($scope.teacher)
            teachercopy.Dob = (new Date($scope.teacher.Dob)).toMSJSON();
            if ($scope.teacher.Doj != null && $scope.teacher.Doj != undefined && $scope.teacher.Doj != "")
                teachercopy.Doj = (new Date($scope.teacher.Doj)).toMSJSON();
            ajax('/SVC/TeacherService/CreateTeacher', {}, {
                method: 'POST', isArray: false, headers: { Accept: 'text' }, transformResponse: [function (data, headersGetter) {
                    return { id: parseInt(data) };
                }]
            }, teachercopy, function (data) {
                $scope.teacher.id = data.id;
                $scope.formsubmitted = true;
                $scope.info = "image";
                $scope.heading = "Teacher Picture";
                $scope.formsubmitted = false;
            });
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
    $scope.image = function () {
        var input = document.getElementById("teacherimage");
        if (input.files.length > 0) {
            var filename = input.files[0].name;
            var url = '/SVC/TeacherService/Uploadteacherimage/' + filename + '/' + $scope.teacher.id;
            var filedata = {};
            filedata.stream = input.files[0];
            ajax(url, {}, {
                method: 'POST', headers: { "Accept": "text", "Content-Type": "image" }, transformRequest: function (data, headersGetter) {

                    var headers = headersGetter();
                    delete headers['Content-Type'];
                    headers['Content-Type'] = "image";
                    return input.files[0];
                }
            }, input.files[0]);
        }
        $state.go("teachers");

    }
    $scope.editTeacher = function () {
        if ($scope.teacherform.$valid) {
            var teachercopy = angular.copy($scope.teacher)
            teachercopy.Dob = (new Date($scope.teacher.Dob)).toMSJSON();
            if ($scope.teacher.Doj != null && $scope.teacher.Doj != undefined && $scope.teacher.Doj != "")
                teachercopy.Doj = (new Date($scope.teacher.Doj)).toMSJSON();
            ajax('/SVC/TeacherService/EditTeacher', {}, {
                method: 'POST', isArray: false, headers: { Accept: 'application/json' }
            }, teachercopy, function (data) {
                $state.go("teachers");
            });
        }
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
        "createdRow": function (row, data, dataIndex) {
            scope.onrowadd(row);
        },
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
                    return "<a class='fa fa-edit compile' title='edit' ui-sref='editteacher(" + JSON.stringify({ id: data }) + ")' href='#/editteacher/{data}'></a>";
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

function isteacherusernamevalid(scope, elm, attrs, ctrl, $q, $timeout, ajax) {
    ctrl.$asyncValidators.isteacherusernamevalid = function (modelValue, viewValue) {
        if (ctrl.$isEmpty(modelValue)) {
            // consider empty model valid
            return $q.when();
        }
        var def = $q.defer();
        $timeout(function () {
            // Mock a delayed response
            var url = attrs.remoteurl;
            var _senddata = {}
            _senddata.ID = scope.teacher.Id;
            _senddata.Email = scope.teacher.Email;
            _senddata[attrs["name"]] = modelValue;
            ajax(url, {}, { method: 'POST', isArray: false, headers: { Accept: 'application/json' } }, _senddata, function (data) {
                if (data.IsValid) {
                    def.resolve();
                }
                else
                    def.reject();
            }, function (data) { });


        }, 2000);

        return def.promise;
    }
}

