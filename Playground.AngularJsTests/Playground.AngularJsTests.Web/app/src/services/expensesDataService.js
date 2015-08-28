(function () {
    'use strict';

    angular.module('app')
        .factory('expensesDataService', function ($http, $q) {
            var service = {
                getExpenses: getExpenses,
                addExpense: addExpense,
                updateExpense: updateExpense,
                getExpense: getExpense,
                deleteExpense: deleteExpense
            };

            return service;

            function getExpenses() {
                var deferred = $q.defer();
                $http.get('/api/Expenses')
                .success(function (response, status, headers, config) {
                    deferred.resolve(response);
                })
                .error(function (response, status, headers, config) {
                    deferred.resolve(null);
                });

                return deferred.promise;
            }

            function addExpense(expenseItem) {
                var deferred = $q.defer();
                $http.post('/api/Expenses', {
                    name: expenseItem.Name,
                    description: expenseItem.Description,
                    ammount: expenseItem.Ammount
                })
                    .success(function (data, status, headers, config) {
                        deferred.resolve(true);
                    })
                    .error(function (data, status, headers, config) {
                        deferred.resolve(false);
                    });
                return deferred.promise;
            }

            function updateExpense(expenseItem) {
                var deferred = $q.defer();
                $http.put('/api/Expenses', {
                    expenseId: expenseItem.ExpenseId,
                    name: expenseItem.Name,
                    description: expenseItem.Description,
                    ammount: expenseItem.Ammount
                })
                    .success(function (data, status, headers, config) {
                        deferred.resolve(true);
                    })
                    .error(function (data, status, headers, config) {
                        deferred.resolve(false);
                    });
                return deferred.promise;
            }

            function getExpense(expenseId) {
                var deferred = $q.defer();

                $http.get('/api/Expenses/' + expenseId)
                .success(function (response, status, headers, config) {
                    deferred.resolve(response);
                })
                .error(function (data, status, headers, config) {
                    deferred.resolve(null);
                });

                return deferred.promise;
            }

            function deleteExpense(expenseId) {
                var deferred = $q.defer();
                $http.delete('/api/Expenses/' + expenseId)
                    .success(function (data, status, headers, config) {
                        deferred.resolve(true);
                    })
                    .error(function (data, status, headers, config) {
                        deferred.resolve(false);
                    });
                return deferred.promise;
            }
        });
})();