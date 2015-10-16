var app = angular.module(appname);

app.controllerProvider.register('acedmicYearController', ['$scope', '$resource', function ($scope, $resource) {
    var token = '4de2a9eaba0b490f8967b418254d1926';
    var query = $resource('/SVC/MaterService/GetAccedmicyears', {}, {
        action: { method: 'GET', isArray: true, headers: { token: token, Accept: 'application/json' } }
    });
    var promise = query.action().$promise;
    promise.then(function (data) {
        $scope.acedmicYears = data
    }, function (data) { console.log(data) });
    $scope.createyear = function createyear() {
        var query = $resource('/SVC/MaterService/CreateAccedmiYear', { }, {
            action: { method: 'POST', isArray: false, headers: { token: token, Accept: 'application/json' } }
        });
        var promise = query.action($scope.year ).$promise;
        promise.then(function (data) {
            $scope.acedmicYears = data

        }, function (data) { console.log(data) });
    }

}]);
function yeartable(scope, element, attribute) {
    $(element).DataTable({
        data: scope.data,
        columns: [
            { data: 'StartYear' },
            { data: 'EndYear' },
            { data: 'Label' },
            { data: 'IsCurrent' }
        ]
    });

}