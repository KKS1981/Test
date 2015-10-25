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
    sp.state('academicyears', {
        url: '/academicyears',
        templateUrl: '/templates/master/academicyears.html',
        controller: 'acedmicYearController',
        resolve: route(['/javascripts/controllers/masters/acedmicyearcontrooler.js'])

    });
    sp.state('createyear', { url: '/createyear', templateUrl: '/templates/master/createyear.html', controller: 'acedmicYearController', resolve: route(['/javascripts/controllers/masters/acedmicyearcontrooler.js']) });
    sp.state('home', { url: '/', templateUrl: '/templates/master/home.html' });
    sp.state('error', { url: '/error', templateUrl: '/templates/error.html' });
    sp.state('classes', { url: '/classes', templateUrl: '/templates/master/classes.html', controller: 'classController', resolve: route(['/javascripts/controllers/masters/classcontroller.js']) });
    sp.state("createclass", { url: '/createclass', templateUrl: '/templates/master/CreateClass.html', controller: 'classController', resolve: route(['/javascripts/controllers/masters/classcontroller.js']) });
    sp.state("editclass", { url: '/editclass/{id:int}', templateUrl: '/templates/master/EditClass.html', controller: 'classController', resolve: route(['/javascripts/controllers/masters/classcontroller.js']) });

    sp.state('createclasslabel', { url: '/createclasslabel', templateUrl: '/templates/master/CreateClassLabel.html', controller: 'classController', resolve: route(['/javascripts/controllers/masters/classcontroller.js']) });
    sp.state('teachers', { url: '/teachers', templateUrl: '/templates/master/teachers.html', controller: 'teacherController', resolve: route(['/javascripts/controllers/masters/teachercontroller.js']) });

}]);
