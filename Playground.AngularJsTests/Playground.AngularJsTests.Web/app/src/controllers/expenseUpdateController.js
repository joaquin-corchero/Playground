(function () {
    'use strict';

    angular.module('app')
        .controller('expenseUpdateController', function ($scope, $routeParams, expensesDataService) {
            var vm = this;

            vm.expenseId = $routeParams.expenseId;
            vm.expense = null;
            vm.errorMessage = "";
            vm.successMessage = "";

            vm.updateExpense = function () {
                vm.successMessage = "";
                vm.errorMessage = "";
                vm.expense.validate();
                if (!vm.expense.isValid) {
                    vm.errorMessage = "There are errors on the form";
                    return;
                }
                expensesDataService
                    .updateExpense(vm.expense).then(
                        function (successful) {
                            if (successful === true)
                                vm.successMessage = "The expense has been updated";
                            else
                                vm.errorMessage = "There was an eror performing your request";
                        }
                    );
            }

            vm.activate = function () {
                if (vm.expenseId === null || vm.expenseId === undefined) {
                    vm.errorMessage = "No expense specified";
                    return;
                }
                vm.successMessage = "";
                vm.errorMessage = "";
                vm.expense = null;
                expensesDataService
                    .getExpense(vm.expenseId).then(
                        function (data) {
                            if (data != null) {
                                vm.expense = new ExpenseItem(data.ExpenseId, data.Name, data.Description, data.Ammount);
                            }
                            else
                                vm.errorMessage = "There was an eror performing your request";
                        }
                    );
            };

            vm.activate();
        });
})();