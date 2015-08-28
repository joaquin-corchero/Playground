(function () {
    'use strict';
    var app = angular.module('app', ['ngRoute']);

    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
        .when('/', { templateUrl: 'src/views/expenses.html' })
        .when('/create', { templateUrl: 'src/views/create.html' })
        .when('/update/:expenseId', { templateUrl: 'src/views/update.html' })
        .when('/delete/:expenseId', { templateUrl: 'src/views/delete.html' })
        .otherwise({ redirectTo: '/' });
    }]);

})();
