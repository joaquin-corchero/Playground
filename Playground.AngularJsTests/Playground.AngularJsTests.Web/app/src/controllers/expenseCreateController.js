(function () {
    'use strict';

    angular.module('app')
        .controller('expenseCreateController', function ($scope, expensesDataService) {
            var vm = this;

            vm.expense = new ExpenseItem();
            vm.errorMessage = "";
            vm.successMessage = "";

            vm.addExpense = function () {
                vm.successMessage = "";
                vm.errorMessage = "";
                vm.expense.validate();
                if (!vm.expense.isValid) {
                    vm.errorMessage = "There are errors on the form";
                    return;
                }
                expensesDataService
                    .addExpense(vm.expense).then(
                        function (successful) {
                            if (successful === true) {
                                vm.successMessage = "The expense has been created";
                                vm.expense = new ExpenseItem();
                            }
                            else
                                vm.errorMessage = "There was an eror performing your request";
                        }
                    );
            }
        });
})();