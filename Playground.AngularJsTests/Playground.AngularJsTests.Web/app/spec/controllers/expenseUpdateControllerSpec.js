/// <reference path="../src/app/app.js" />
describe("Expense update controller", function () {
    var $controllerConstructor;
    var scope;
    var asyncHelper;
    var dataService;
    var ctrl;
    var routeParams = { expenseId: '5' };
    var expense = new ExpenseItem(routeParams.expenseId, 'name', 'long enough description', 50.00);
    var spyGetExpense;
    var fakeGetExpense;

    beforeEach(module('app'));

    beforeEach(inject(function (_$controller_, $rootScope, $q) {
        $controllerConstructor = _$controller_;
        scope = $rootScope.$new();
        asyncHelper = $q;
    }));

    function setFakeGetExpense(result) {
        fakeGetExpense = function (expenseId) {
            var deferred = asyncHelper.defer();
            deferred.resolve(result);
            return deferred.promise;
        };
    }

    beforeEach(inject(function (expensesDataService) {
        dataService = expensesDataService;
    }));

    beforeEach(function () {
        setFakeGetExpense(expense);
        spyGetExpense = spyOn(dataService, 'getExpense').and.callFake(fakeGetExpense);
        ctrl = $controllerConstructor('expenseUpdateController', { $scope: scope, $routeParams: routeParams });
    });

    describe('getting the expense', function () {

        it('should take the expenseId if specified', function () {
            expect(ctrl.expenseId).toEqual(routeParams.expenseId);
        });

        it('should set error message if no expenseId is specified', function () {
            routeParams = {};
            ctrl = $controllerConstructor('expenseUpdateController', { $scope: scope, $routeParams: routeParams });
            expect(ctrl.errorMessage).toEqual("No expense specified");
            routeParams = { expenseId: '5' };
        });

        it('the success message should be empty', function () {
            expect(ctrl.successMessage).toEqual("");
        });

        if ('should populate the expense when the record is found', function () {
            scope.$apply();
            expect(ctrl.expense).toEqual(expense);
        });

        it('should show error message when the expense can not be found', function () {
            setFakeGetExpense(null);
            spyGetExpense.and.callFake(fakeGetExpense);
            ctrl = $controllerConstructor('expenseUpdateController', { $scope: scope, $routeParams: routeParams });
            scope.$apply();
            expect(ctrl.errorMessage).toEqual("There was an eror performing your request");
            expect(ctrl.expense).toEqual(null);
        });
    });

    describe('updating the expense', function () {
        var spyUpdateExpense;

        function setFakeUpdateExpense(result) {
            fakeUpdateExpense = function (expense) {
                var deferred = asyncHelper.defer();
                deferred.resolve(result);
                return deferred.promise;
            };
        }

        beforeEach(inject(function () {
            setFakeUpdateExpense(true);
            spyUpdateExpense = spyOn(dataService, 'updateExpense');
            ctrl.expense = expense;
            spyUpdateExpense.and.callFake(fakeUpdateExpense);
        }));

        function execute(fakeResult)
        {
            setFakeUpdateExpense(fakeResult);
            spyUpdateExpense.and.callFake(fakeUpdateExpense);
            ctrl.updateExpense();
            scope.$apply()
        }

        it('should call the update expense from the service', function () {
            execute(true);
            expect(spyUpdateExpense.calls.count()).toEqual(1);
        });

        it('should display error message when the expense is invalid and reset success message', function () {
            ctrl.expense.Name = "a";
            ctrl.updateExpense();
            expect(ctrl.errorMessage).toEqual("There are errors on the form");
            expect(ctrl.successMessage).toEqual("");
            ctrl.expense.Name = "Name";
        });

        it('should set success message when the update works and reset the error message', function () {
            execute(true);
            expect(ctrl.successMessage).toEqual("The expense has been updated");
            expect(ctrl.errorMessage).toEqual("");
        });


        it('should set the error message when the update expense is not successful', function () {
            ctrl.expense = expense;
            execute(false);
            expect(ctrl.errorMessage).toEqual("There was an eror performing your request");
            expect(ctrl.successMessage).toEqual("");
        });
    });
});