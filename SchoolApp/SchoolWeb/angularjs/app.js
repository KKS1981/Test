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
app.directive('chosen', [function () {
    var obj = {};
    obj.restrict = 'C',
    obj.link = function (scope, element, attribute) {

        scope.$watch(attribute.watch, function (value1,value2) {
            $(element).chosen({ width: "100%" });
            
            $(element).trigger('chosen:updated');
        });

        scope.$watch(attribute.ngModel, function (value1, value2) {
           
            $(element).trigger('chosen:updated');
        });

    }
    return obj;
}])
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

app.factory('ajax', ['$resource', 'token', '$state', function ($resource, token, $state) {
    var obj = function (url, paramDefaults, info, data, success, fail) {
        //get token from cokkies
        var key = token.gettoken();
        if (info != undefined && info != null) {
            if (info.headers == null || info.headers == undefined) {
                info.headers = { token: key };
            }
            else {
                info.headers.token = key;
            }
        }
        var query = $resource(url, paramDefaults, {
            action: info
        });
        if (data != null && data != undefined)
            var promise = query.action(data).$promise;
        else
            var promise = query.action().$promise;
        promise.then(
            function (data) {
                if (typeof success == 'function') {
                    success(data);
                }
            },
        function (data) {
            if (typeof fail == 'function') {
                fail(data);
            }
            else {
                $state.go('error');
            }
        });
    }
    return obj;

}]);


