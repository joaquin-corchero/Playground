'use strict';

describe("Expenses data service", function () {
    var dataService;
    var httpHelper;
    var expenseItem;

    beforeEach(module('app'));

    beforeEach(inject(function (expensesDataService, _$httpBackend_) {
        dataService = expensesDataService;
        httpHelper = _$httpBackend_;
    }));

    beforeEach(function () {
        expenseItem = new ExpenseItem('2', 'taxi', 'airport', 98.95);
    });

    describe("Get expenses", function () {
        it('should call the /api/Expenses to get the expenses', function () {
            var expected = [expenseItem];
            httpHelper.expectGET('/api/Expenses').respond(expected);
            var actual = dataService.getExpenses();

            httpHelper.flush();
            expect(expected).toEqual(actual.$$state.value);
        });
    });

    describe("Get expense", function () {
        it('should call the /api/Expenses/expenseId to get the expense', function () {
            var expected = [expenseItem];
            httpHelper.expectGET('/api/Expenses/' + expenseItem.expenseId).respond(expected);
            var actual = dataService.getExpense(expenseItem.expenseId);

            httpHelper.flush();
            expect(expected).toEqual(actual.$$state.value);
        });
    });

    describe("Add expense", function () {
        it('should post to /api/Expenses to add the expense', function () {
            var expected = true;
            httpHelper.expectPOST('/api/Expenses').respond(expected);
            var actual = dataService.addExpense(expenseItem);
            httpHelper.flush();
            expect(expected).toEqual(actual.$$state.value);
        });
    });

    describe("update expense", function () {
        it('should post to /api/Expenses to update the expense', function () {
            var expected = true;
            httpHelper.expectPUT('/api/Expenses').respond(expected);
            var actual = dataService.updateExpense(expenseItem);
            httpHelper.flush();
            expect(expected).toEqual(actual.$$state.value);
        });
    });

    describe("delete expense", function () {
        it('should delete to /api/Expenses to delete the expense', function () {
            var expected = true;
            httpHelper.expectDELETE('/api/Expenses/5').respond(expected);
            var actual = dataService.deleteExpense(5);
            httpHelper.flush();
            expect(expected).toEqual(actual.$$state.value);
        });
    });
});