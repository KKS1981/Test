var app = angular.module(appname);
app.config(['$urlRouterProvider', '$stateProvider', '$controllerProvider', function (urp, sp, $controllerProvider) {
    var route = function (url) {
        var obj = {};
        obj.load = ['$q', '$rootScope', function ($q, $rootScope) {
            var deferred = $q.defer();
            require(
              url // (will look for controller.js)
            , function () {
                $rootScope.$apply(function () { deferred.resolve(); });
            });
            return deferred.promise;
        }];
        return obj;
    }
    app.controllerProvider = $controllerProvider;
    urp.otherwise('/');
    sp.state('classes', { url: '/classes', templateUrl: '/templates/master/classes.html' });
    sp.state('academicyears', {
        url: '/academicyears',
        templateUrl: '/templates/master/academicyears.html',
        controller: 'acedmicYearController',
        resolve: route(['/javascripts/controllers/masters/acedmicyearcontrooler.js'])

    });
    sp.state('home', { url: '/', templateUrl: '/templates/master/home.html' });

}]);
