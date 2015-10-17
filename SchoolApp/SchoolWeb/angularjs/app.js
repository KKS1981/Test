var appname = 'schoolApp';
var app = angular.module(appname, ['ui.router', 'ngResource']);
app.directive('datatable', ['$compile', function ($compile) {
    var obj = {};
    obj.restrict = 'A';

    obj.link = function (scope, element, attribute) {
        scope.$watch(attribute.data, function (value) {
            if (value != null && value != undefined) {
                window[attribute.functionname](scope, element, attribute);
                var elem = element.find(".compile")
                for (var i = 0; i < elem.length; i++) {
                    $compile(elem[i])(scope)
                }

            }


        })
    }
    return obj;
}]);
app.factory("token", [function () {
    var obj = {};
    obj.gettoken = function () {
        var i, x, y, ARRcookies = document.cookie.split(";");
        for (i = 0; i < ARRcookies.length; i++) {
            x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("="));
            y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1);
            x = x.replace(/^\s+|\s+$/g, "");
            if (x == "key") {
                return unescape(y);
            }
        }
        if (i == ARRcookies.length) {
            alert("please sign in again");
        }
    };
    return obj;
}
]);


