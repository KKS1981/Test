var appname = 'schoolApp';
var app = angular.module(appname, ['ui.router', 'ngResource']);
app.directive('datatable', [function () {
    var obj = {};
    obj.restrict = 'A';
    obj.scope = {
       data: '=data'
    },
    obj.link = function (scope, element, attribute) {
        scope.$watch("data", function (value) {
            if (value != null && value != undefined) {
                window[attribute.functionname](scope, element, attribute);
            }
            

        })
    }
    return obj;
}]);