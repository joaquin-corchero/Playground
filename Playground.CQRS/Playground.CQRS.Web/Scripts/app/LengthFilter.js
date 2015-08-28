var app = angular.module('myApp', []);

app.filter('length', function () {
        return function (text) {
            return ('' + (text || '')).length;
        }
    });