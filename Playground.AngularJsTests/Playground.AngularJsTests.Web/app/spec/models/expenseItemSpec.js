describe('Expense item', function () {
    var expenseItem = new ExpenseItem("azdf", "Valid name", "Valid description", 500);

    function GetStringOfLength(length)
    {
        var result = "";
        var counter = 1;
        while(result.length < length)
        {
            result = result + "A";
            counter++;
        }
        return result;
    }

    describe('Expense name validation', function () {
        it('should set error message when the name is null', function () {
            expenseItem.Name = null;
            expenseItem.validate();
            expect(expenseItem.isValid).toEqual(false);
            expect(expenseItem.nameError).toEqual("The name must be between 4 and 20 characters");
        });

        it('should set error message when name is under 4 characters', function () {
            expenseItem.Name = GetStringOfLength(3);
            expenseItem.validate();
            expect(expenseItem.isValid).toEqual(false);
            expect(expenseItem.nameError).toEqual("The name must be between 4 and 20 characters");
        });

        it('should set error message when name is over 20 characters', function () {
            expenseItem.Name = GetStringOfLength(21);
            expenseItem.validate();
            expect(expenseItem.isValid).toEqual(false);
            expect(expenseItem.nameError).toEqual("The name must be between 4 and 20 characters");
        });

        it('should not set error message when name is 20 characters', function () {
            expenseItem.Name = GetStringOfLength(20);
            expenseItem.validate();
            expect(expenseItem.isValid).toEqual(true);
            expect(expenseItem.nameError).toEqual("");
        });

        it('should not set error message when name is 4 characters', function () {
            expenseItem.Name = GetStringOfLength(4);;
            expenseItem.validate();
            expect(expenseItem.isValid).toEqual(true);
            expect(expenseItem.nameError).toEqual("");
        });
    });

    describe('Expense description validation', function () {
        it('should set error message when the description is null', function () {
            expenseItem.Description = null;
            expenseItem.validate();
            expect(expenseItem.isValid).toEqual(false);
            expect(expenseItem.descriptionError).toEqual("The description must be between 10 and 50 characters");
        });

        it('should set error message when description is under 10 characters', function () {
            expenseItem.Description = GetStringOfLength(3);;
            expenseItem.validate();
            expect(expenseItem.isValid).toEqual(false);
            expect(expenseItem.descriptionError).toEqual("The description must be between 10 and 50 characters");
        });

        it('should set error message when description is over 50 characters', function () {
            expenseItem.Description = GetStringOfLength(51);
            expenseItem.validate();
            expect(expenseItem.isValid).toEqual(false);
            expect(expenseItem.descriptionError).toEqual("The description must be between 10 and 50 characters");
        });

        it('should not set error message when description is 50 characters', function () {
            expenseItem.Description = GetStringOfLength(50);
            expenseItem.validate();
            expect(expenseItem.isValid).toEqual(true);
            expect(expenseItem.descriptionError).toEqual("");
        });


        it('should not set error message when description is 10 characters', function () {
            expenseItem.Description = GetStringOfLength(10);
            expenseItem.validate();
            expect(expenseItem.isValid).toEqual(true);
            expect(expenseItem.descriptionError).toEqual("");
        });
    });
});