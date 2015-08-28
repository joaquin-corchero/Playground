/// <reference path="../jasmine.js" />
/// <reference path="../angular.js" />
/// <reference path="../angular-mocks.js" />
/// <reference path="../app/LengthFilter.js" />

describe('length filter', function () {
    beforeEach(module('myApp'));

    beforeEach(inject(function (_$filter_) {
        // The injector unwraps the underscores (_) from around the parameter names when matching
        $filter = _$filter_;
    }));

    it('returns 0 when given null', function () {
        var $scope = {};
        var length = $filter('length');
        expect(length(null)).toEqual(0);
    });

    it('returns the correct value when given a string of chars', function () {
        var length = $filter('length');
        expect(length('abc')).toEqual(3);
    });
});