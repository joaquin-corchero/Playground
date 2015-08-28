(function () {
    'use strict';

    angular.module('app')
       .controller('expenseDeleteController', function ($scope, $routeParams, expensesDataService) {
           var vm = this;

           vm.expenseId = $routeParams.expenseId;

           vm.deleteExpense = function () {
               vm.successMessage = "";
               vm.errorMessage = "";
               if (vm.expenseId === null || vm.expenseId === undefined) {
                   vm.errorMessage = "No expense selected";
                   return;
               }

               vm.expense = null;
               expensesDataService
                   .deleteExpense(vm.expenseId).then(
                       function (data) {
                           if (data === true)
                               vm.successMessage = "The expense has been deleted";
                           else
                               vm.errorMessage = "There was an eror performing your request";
                       }
                   );
           };

           vm.deleteExpense();
       });
})();