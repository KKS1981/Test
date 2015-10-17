var app = angular.module(appname);

app.controllerProvider.register('acedmicYearController', ['$scope', '$resource', '$compile', '$state', 'token', function ($scope, $resource, $compile, $state, token) {
    //get token from cokkies
    var key = token.gettoken();
    //GetAccedmicyears
    var query = $resource('/SVC/MaterService/GetAccedmicyears', {}, {
        action: { method: 'GET', isArray: true, headers: { token: key, Accept: 'application/json' } }
    });
    var promise = query.action().$promise;
    promise.then(function (data) {
        $scope.acedmicYears = data
    }, function (data) { console.log(data) });
    //Create AcademicYear
    $scope.createyear = function createyear() {
        var query = $resource('/SVC/MaterService/CreateAccedmiYear', {}, {
            action: { method: 'POST', isArray: false, headers: { token: key, Accept: 'application/json' } }
        });
        var promise = query.action($scope.year).$promise;
        promise.then(function (data) {
            $scope.acedmicYears = data
            $state.go('academicyears');
        }, function (data) { });
    }
    //Make year Active
    $scope.makeActive = function (yearid) {
        var query = $resource('/SVC/MaterService/SetCurrentAcademicYear', {}, {
            action: { method: 'POST', headers: { token: key, Accept: 'application/json' } }
        });
        var promise = query.action(yearid).$promise;
        promise.then(function () {
            //after making year active fetch all years.
            var query = $resource('/SVC/MaterService/GetAccedmicyears', {}, {
                action: { method: 'GET', isArray: true, headers: { token: key, Accept: 'application/json' } }
            });
            var promise = query.action().$promise;
            promise.then(function (data) {
                $scope.acedmicYears = data
            }, function (data) { });

        });
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

