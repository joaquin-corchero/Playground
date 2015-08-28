/// <reference path="../src/app/app.js" />
describe("Expense create controller", function () {
    var $controllerConstructor;
    var scope;
    var asyncHelper;
    var dataService;
    var ctrl;
    var spyAddExpense;

    beforeEach(module('app'));

    beforeEach(inject(function (_$controller_, $rootScope, $q) {
        $controllerConstructor = _$controller_;
        scope = $rootScope.$new();
        asyncHelper = $q;
        ctrl = $controllerConstructor('expenseCreateController', { $scope: scope });
    }));

    function setFakeAddExpense(result) {
        fakeAddExpense = function (expense) {
            var deferred = asyncHelper.defer();
            deferred.resolve(result);
            return deferred.promise;
        };
    }

    beforeEach(inject(function (expensesDataService) {
        dataService = expensesDataService;
        spyAddExpense = spyOn(dataService, 'addExpense');
        ctrl.expense = new ExpenseItem('5', 'name', 'long enough description', 50.00);
        setFakeAddExpense(true);
    }));

    function execute()
    {
        spyAddExpense.and.callFake(fakeAddExpense);
        ctrl.addExpense();
        scope.$apply();
    }

    it('should call the add expenses from the service', function () {
        execute();
        expect(spyAddExpense.calls.count()).toEqual(1);
    });

    it('should display error message when the expense is invalid and reset success message', function () {
        ctrl.expense.Name = "a";
        execute();
        expect(ctrl.errorMessage).toEqual("There are errors on the form");
        expect(ctrl.successMessage).toEqual("");
    });

    it('should set success message when the addition works and reset the error message', function () {
        execute();
        expect(ctrl.successMessage).toEqual("The expense has been created");
        expect(ctrl.errorMessage).toEqual("");
    });


    it('should set the error message when the add expense is not successful', function () {
        setFakeAddExpense(false);
        execute();
        expect(ctrl.errorMessage).toEqual("There was an eror performing your request");
    });

    it ('should reset the controller expense after creating it, so no duplication happens', function () {
        execute();
        var expected = new ExpenseItem();
        expect(ctrl.expense.Name).toEqual(expected.Name);
        expect(ctrl.expense.Description).toEqual(expected.Description);
        expect(ctrl.expense.Ammount).toEqual(expected.Ammount);
    });
});