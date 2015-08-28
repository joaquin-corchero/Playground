/// <reference path="../src/app/app.js" />
describe("Expenses controller", function () {
    var $controllerConstructor;
    var scope;
    var asyncHelper;
    var dataService;
    var spyGetExpenses;
    var expenseItems;

    beforeEach(module('app'));

    beforeEach(inject(function (_$controller_, $rootScope, $q) {
        $controllerConstructor = _$controller_;
        scope = $rootScope.$new();
        asyncHelper = $q;
    }));

    beforeEach(inject(function (expensesDataService) {
        dataService = expensesDataService;
    }));

    beforeEach(function () {
        expenseItems = [
            new ExpenseItem('fake taxi', 'airport', 98.95),
            new ExpenseItem('fake lunch', 'at airport', 10.95)
        ];

        spyGetExpenses = spyOn(dataService, "getExpenses").and.callFake(function () {
            var deferred = asyncHelper.defer();
            deferred.resolve(expenseItems);
            return deferred.promise;
        });
    });

    it('should call the get expenses from the service', function () {
        var ctrl = $controllerConstructor('expensesController', { $scope: scope });
        scope.$apply();
        expect(spyGetExpenses).toHaveBeenCalled();
    });

    it('should assign the values returned on the service to the expense items', function () {
        var ctrl = $controllerConstructor('expensesController', { $scope: scope });
        scope.$apply();
        expect(expenseItems).toEqual(ctrl.expenseItems);
    });
});