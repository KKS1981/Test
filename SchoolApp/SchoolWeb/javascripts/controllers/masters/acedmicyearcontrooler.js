var app = angular.module(appname);

app.controllerProvider.register('acedmicYearController', ['$scope', '$compile', '$state', 'ajax', function ($scope, $compile, $state, ajax) {

    //GetAccedmicyears
    ajax('/SVC/MaterService/GetAccedmicyears', {}, { method: 'GET', isArray: true, headers: { Accept: 'application/json' } }, null, function (data) {
        $scope.acedmicYears = data
    });
    //var promise = query.action().$promise;
    //promise.then(function (data) {
    //    $scope.acedmicYears = data
    //}, function (data) { console.log(data) });
    //Create AcademicYear
    $scope.createyear = function createyear() {
        var query = ajax('/SVC/MaterService/CreateAccedmiYear', {}, { method: 'POST', isArray: false, headers: { Accept: 'application/json' } }, $scope.year, function (data) {
            $scope.acedmicYears = data
            $state.go('academicyears');
        });
    }
    //Make year Active
    $scope.makeActive = function (yearid) {
        var query = ajax('/SVC/MaterService/SetCurrentAcademicYear', {}, { method: 'POST', headers: { Accept: 'application/json' } }, yearid, function (data) {
            ajax('/SVC/MaterService/GetAccedmicyears', {}, { method: 'GET', isArray: true, headers: { Accept: 'application/json' } }, null, function (data) {
                $scope.acedmicYears = data
            });
        }
        );
        
    }


}]);
function yeartable(scope, element, attribute) {
    var a = $(element);
    if (a.hasClass("dataTable")) {
        $(element).dataTable().fnDestroy();
    }
    a.DataTable({
        data: scope[attribute.data],
        columns: [
            { data: 'StartYear' },
            { data: 'EndYear' },
            { data: 'Label' },
            { data: 'IsCurrent' },
            { data: 'Id' },
        ],
        "columnDefs": [
            {
                "render": function (data, type, row) {
                    if (data) {
                        return "<i class='fa fa-check-circle'></i>";
                    }
                    else {
                        return "<i class='fa  fa-ban'></i>";
                    }
                },
                "targets": 3
            },
            {
                "render": function (data, type, row) {
                    if (row.IsCurrent) {
                        return "";
                    }
                    else {
                        return "<button class='btn btn-primary compile' ng-click='makeActive(" + data + ")'>Make Active</button>";
                    }
                },
                "targets": 4
            },
        ]
    });

}

