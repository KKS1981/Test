var app = angular.module(appname);

app.controllerProvider.register('acedmicYearController', ['$scope', '$resource', function ($scope, $resource) {
    var query = $resource('/SVC/MaterService/GetAccedmicyears', {}, {
        action: { method: 'GET', isArray: true, headers: { token: '4de2a9eaba0b490f8967b418254d1926', Accept: 'application/json' } }
    });
    var promise = query.action().$promise;
    promise.then(function (data) {
        $scope.acedmicYears = data

    }, function (data) { console.log(data) });
    $scope.columns = ['StartYear', 'EndYear', 'Label', 'IsCurrent'];
}]);