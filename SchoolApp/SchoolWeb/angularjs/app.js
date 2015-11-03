var appname = 'schoolApp';
var app = angular.module(appname, ['ui.router', 'ngResource', 'ngMessages']);
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

        scope.$watch(attribute.watch, function (value1, value2) {
            $(element).chosen({ width: "100%" });

            $(element).trigger('chosen:updated');
        });

        scope.$watch(attribute.ngModel, function (value1, value2) {

            $(element).trigger('chosen:updated');
        });

    }
    return obj;
}])
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
app.directive('compare', [function () {
    var obj = {};
    obj.require = 'ngModel';
    obj.restrict = 'A';
    obj.link = function (scope, elm, attrs, ctrl) {
        ctrl.$validators.compare = function (modelValue, viewValue) {
            if (ctrl.$isEmpty(modelValue)) {
                // consider empty models to be valid
                return true;
            }
             
            var a = $(document.getElementsByName(attrs.compare)).val();
            if (a == modelValue) {
                // it is valid
                return true;
            }

            // it is invalid
            return false;
        };
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

app.directive("remote", ["$q", "$timeout", "ajax", function ($q, $timeout, ajax) {
    var obj = {};
    obj.restrict = "A";
    obj.require = "ngModel";
    obj.link = function (scope, elm, attrs, ctrl) {
        ctrl.$asyncValidators.remote = function (modelValue, viewValue) {
            if (ctrl.$isEmpty(modelValue)) {
                // consider empty model valid
                return $q.when();
            }
            var def = $q.defer();
            $timeout(function () {
                // Mock a delayed response
                var url = attrs.remoteurl;
                var _senddata = {}
                if (!ctrl.$isEmpty(attrs.remotevalues)) {
                    var values = attrs.remotevalues.split(",")

                    for (var i = 0; i < values.length; i++) {
                        _senddata[values[i]] = scope[values[i]];
                    }
                }               
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
    return obj;
}]);

function toDateString(date) {
    var a = new Date(eval(
date.match(/\/(.*)\//).pop()))
    var day = a.getDay();
    var month = a.getMonth();
    var year = a.getFullYear();
    var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nev', 'Dec'];
    var string = day + " " + months[month] + " " + year;
    return string;
}




