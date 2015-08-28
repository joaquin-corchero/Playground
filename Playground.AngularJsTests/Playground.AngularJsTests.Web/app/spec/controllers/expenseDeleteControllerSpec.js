describe("Expenses delete controller", function () {
    var $controllerConstructor;
    var scope;
    var asyncHelper;
    var dataService;
    var ctrl;
    var routeParams = { expenseId: '5' };
    var spyDeleteExpense;
    var fakeDeleteExpense;

    beforeEach(module('app'));

    beforeEach(inject(function (_$controller_, $rootScope, $q) {
        $controllerConstructor = _$controller_;
        scope = $rootScope.$new();
        asyncHelper = $q;
    }));

    function setFakeDeleteExpense(result) {
        fakeDeleteExpense = function (expenseId) {
            var deferred = asyncHelper.defer();
            deferred.resolve(result);
            return deferred.promise;
        };
    }

    beforeEach(inject(function (expensesDataService) {
        dataService = expensesDataService;
    }));

    beforeEach(function () {
        setFakeDeleteExpense(true);
        spyDeleteExpense = spyOn(dataService, 'deleteExpense').and.callFake(fakeDeleteExpense);
        ctrl = $controllerConstructor('expenseDeleteController', { $scope: scope, $routeParams: routeParams });
    });

    it('should error message set and success message empty when expense id is not passed', function () {
        routeParams = {};
        ctrl = $controllerConstructor('expenseDeleteController', { $scope: scope, $routeParams: routeParams });
        expect(ctrl.errorMessage).toEqual("No expense selected");
        expect(ctrl.successMessage).toEqual("");
        routeParams = { expenseId: '5' };
    });

    it('should take the expenseId if specified', function () {
        expect(ctrl.expenseId).toEqual(routeParams.expenseId);
    });

    it('should call the delete expenses method from the service if id provided', function(){
        scope.$apply();
        expect(spyDeleteExpense.calls.count()).toEqual(1);
    });

    it('should set success message when the delete is successful', function () {
        scope.$apply();
        expect(ctrl.successMessage).toEqual('The expense has been deleted');
        expect(ctrl.errorMessage).toEqual('');
    });

    it('should set error message when the delete is not successful', function () {
        setFakeDeleteExpense(false);
        spyDeleteExpense.and.callFake(fakeDeleteExpense);
        ctrl = $controllerConstructor('expenseDeleteController', { $scope: scope, $routeParams: routeParams });
        scope.$apply();
        expect(ctrl.errorMessage).toEqual('There was an eror performing your request');
        expect(ctrl.successMessage).toEqual('');
    });

});