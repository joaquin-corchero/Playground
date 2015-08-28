(function () {
    'use strict';

    angular.module('app')
        .controller('expensesController', function ($scope, expensesDataService) {
            var vm = this;

            vm.expenseItems = [];

            vm.activate = function () {
                expensesDataService.getExpenses().then(
                    function (data) {
                        vm.expenseItems = data;
                    });
            };

            vm.activate();
        });
})();