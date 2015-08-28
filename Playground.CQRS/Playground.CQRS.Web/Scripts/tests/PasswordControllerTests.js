/// <reference path="../jasmine.js" />
/// <reference path="../angular.js" />
/// <reference path="../angular-mocks.js" />
/// <reference path="../app/PasswordController.js" />

describe('PasswordController', function () {
    beforeEach(module('myApp'));

    var $controller;

    beforeEach(inject(function (_$controller_) {
        // The injector unwraps the underscores (_) from around the parameter names when matching
        $controller = _$controller_;
    }));

    describe('$scope.grade', function () {
        it('sets the strength to "strong" if the password length is >8 chars', function () {
            var $scope = {};
            var controller = $controller('PasswordController', { $scope: $scope });
            $scope.password = 'longerthaneightchars';
            $scope.grade();
            expect($scope.strength).toEqual('strong');
        });

        it('sets the strength to "medium" if the password length is >3 chars', function () {
            var $scope = {};
            var controller = $controller('PasswordController', { $scope: $scope });
            $scope.password = 'shorther';
            $scope.grade();
            expect($scope.strength).toEqual('medium');
        });

        it('sets the strength to "weak" if the password length is <=3 chars', function () {
            var $scope = {};
            var controller = $controller('PasswordController', { $scope: $scope });
            $scope.password = 'wea';
            $scope.grade();
            expect($scope.strength).toEqual('weak');
        });
    });


});