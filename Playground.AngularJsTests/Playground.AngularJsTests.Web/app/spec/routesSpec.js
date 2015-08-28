'use strict';

describe('Routing', function () {

    beforeEach(module('app'));

    it('the routes should be correct', inject(function ($route) {
        expect($route.routes[null].redirectTo).toEqual('/');
        expect($route.routes['/'].templateUrl).toEqual('src/views/expenses.html');
        expect($route.routes['/create'].templateUrl).toEqual('src/views/create.html');
        expect($route.routes['/update/:expenseId'].templateUrl).toEqual('src/views/update.html');
        expect($route.routes['/delete/:expenseId'].templateUrl).toEqual('src/views/delete.html');
    }));
});